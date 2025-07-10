using System.Security.Claims;

using DH.Entity;
using DH.RateLimter;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using NewLife;
using NewLife.Caching;
using NewLife.Cube.Services;
using NewLife.Log;

using Pek.Exceptions;
using Pek.Helpers;
using Pek.Models;
using Pek.MVC;
using Pek.NCube;
using Pek.Permissions;
using Pek.Permissions.Identity.JwtBearer;
using Pek.Swagger;

using XCode;
using XCode.Membership;

namespace Pek.VueNetCoreT.Server.Controllers.Api.V1;

/// <summary>
/// 用户接口
/// </summary>
/// <remarks>
/// 建立时间: 2025-07-09
/// </remarks>
[Produces("application/json")]
[CustomRoute(ApiVersions.V1)]
[JwtAuthorize("Vue")]
public class UserController : PekControllerBaseX
{
    /// <summary>
    /// 缓存提供者
    /// </summary>
    private readonly ICacheProvider Cache;

    /// <summary>
    /// Jwt令牌构建器
    /// </summary>
    public IJsonWebTokenBuilder TokenBuilder { get; }

    /// <summary>
    /// Jwt令牌存储器
    /// </summary>
    public IJsonWebTokenStore TokenStore { get; }

    /// <summary>
    /// 令牌Payload存储器
    /// </summary>
    public ITokenPayloadStore PayloadStore { get; }

    /// <summary>
    /// 密码服务
    /// </summary>
    private readonly PasswordService? _passwordService;

    /// <summary>
    /// 初始化一个<see cref="UserController"/>类型的实例
    /// </summary>
    /// <param name="tokenBuilder">Jwt令牌构建器</param>
    /// <param name="tokenStore">Jwt令牌存储器</param>
    /// <param name="payloadStore">令牌Payload存储器</param>
    /// <param name="passwordService">密码管理</param>
    /// <param name="cache"></param>
    public UserController(ICacheProvider cache, IJsonWebTokenBuilder tokenBuilder, IJsonWebTokenStore tokenStore, ITokenPayloadStore payloadStore, PasswordService passwordService)
    {
        Cache = cache;
        TokenBuilder = tokenBuilder;
        TokenStore = tokenStore;
        PayloadStore = payloadStore;
        _passwordService = passwordService;
    }

    /// <summary>
    /// 用户登录接口
    /// </summary>
    /// <returns></returns>
    [HttpPost, Route("Login")]
    [AllowAnonymous]
    [RateValve(Policy = Policy.Ip, Limit = 60, Duration = 3600)]
    public IActionResult Login([FromForm] String Name, [FromForm] String PassWord, [FromForm] String Code, [FromForm] String CodeId, [FromHeader] String? Lng)
    {
        var result = new DGResult();

        try
        {
            if (CodeId.IsNullOrWhiteSpace())
            {
                result.Message = GetResource("验证码有误", Lng);
                return result;
            }

            if (!Cache.Cache.ContainsKey(CodeId))
            {
                result.Message = GetResource("验证码过期", Lng);
                return result;
            }

            if (!Cache.Cache.Get<String>(CodeId).EqualIgnoreCase(Code))
            {
                result.Message = GetResource("验证码不正确", Lng);
                return result;
            }

            if (Name.IsNullOrWhiteSpace())
            {
                result.Message = GetResource("账号不能为空", Lng);
                return result;
            }

            if (PassWord.IsNullOrWhiteSpace())
            {
                result.Message = GetResource("密码不能为空", Lng);
                return result;
            }

            var provider = ManageProvider.Provider;
            if (ModelState.IsValid && provider?.Login(Name, PassWord, false) != null)
            {
                var model = ManageProvider.User;
                if (model!.Enable == false)
                {
                    result.Message = GetResource("用户被禁用", Lng);
                    return result;
                }

                //var modelUserEx = UserEx.FindById(ManageProvider.User?.ID ?? -1);
                //if (modelUserEx == null)
                //{
                //    modelUserEx = new UserEx();
                //    modelUserEx.Id = ManageProvider.User?.ID ?? -1;
                //}
                //modelUserEx.Update();

                var payload = new Dictionary<String, String>
                {
                    ["clientId"] = ManageProvider.User?.ID.ToString() ?? "-1",
                    [ClaimTypes.Sid] = ManageProvider.User?.ID.ToString() ?? "-1",
                    [ClaimTypes.Name] = ManageProvider.User?.Name.ToString() ?? String.Empty,
                    [ClaimTypes.NameIdentifier] = ManageProvider.User?.Name ?? String.Empty,
                    ["From"] = "Vue",
                };
                var resultToken = TokenBuilder.Create(payload);  //获取Token

                result.Data = new { Token = resultToken, UId = ManageProvider.User?.ID, UserName = ManageProvider.User?.Name, Img = ManageProvider.User?.Avatar };
            }
            else
            {
                result.Message = GetResource("用户名和密码不匹配", Lng);
                return result;
            }
            result.Code = StateCode.Ok;
            return result;
        }
        catch (DHException ex)
        {
            result.Message = ex.Message;
            return result;
        }
        catch (EntityException ex)
        {
            result.Message = ex.Message;
            return result;
        }
        catch (Exception ex)
        {
            XTrace.WriteException(ex);
            var innerEx = GerInnerException(ex);
            var showerrmsg = GetResource("未知错误", Lng);
            if (innerEx is DHException)
            {
                showerrmsg = innerEx.Message;
            }
            else
            {
                XTrace.Log.Error(String.Format(GetResource("用户登录异常", Lng), Name, ex));
            }
            result.Message = showerrmsg;
            return result;
        }
    }

    /// <summary>
    /// 退出登录
    /// </summary>
    /// <param name="AccessToken">AccessToken</param>
    /// <param name="RefreshToken">RefreshToken</param>
    /// <param name="Lng">语言标识符</param>
    /// <returns></returns>
    [HttpPost, Route("Logout")]
    //[ApiSignature]
    public IActionResult Logout([FromForm] String AccessToken, [FromForm] String RefreshToken, [FromHeader] String Lng)
    {
        var result = new DvResult();

        //var UId = HttpContext.Items["clientId"].SafeString();
        var UId = DHWeb.Identity.GetValue(ClaimTypes.Sid);

        var model = UserE.FindByID(UId.ToInt());
        if (model == null)
        {
            result.message = GetResource("未获取到当前用户数据！", Lng);
            return result;
        }

        TokenStore.RemoveToken(AccessToken);
        TokenStore.RemoveRefreshToken(RefreshToken);

        var provider = ManageProvider.Provider;
        provider?.Logout();

        UserE.WriteLog(LocaleStringResource.GetResource("退出登录", Lng), true, String.Format(LocaleStringResource.GetResource("用户[{0}]退出登录", Lng), model.Name));

        result.code = StateCode.Ok;
        return result;
    }
}
