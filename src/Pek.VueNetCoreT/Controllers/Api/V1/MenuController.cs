using System.Security.Claims;

using DH.Entity;

using Microsoft.AspNetCore.Mvc;

using NewLife;

using Pek.Helpers;
using Pek.Models;
using Pek.MVC;
using Pek.NCube;
using Pek.Permissions;
using Pek.Swagger;

namespace Pek.VueNetCoreT.Server.Controllers.Api.V1;

/// <summary>
/// 菜单接口
/// </summary>
/// <remarks>
/// 建立时间: 2025-07-09
/// </remarks>
[Produces("application/json")]
[CustomRoute(ApiVersions.V1)]
[JwtAuthorize("Vue")]
public class MenuController : PekControllerBaseX
{
    /// <summary>
    /// 获取菜单树形结构
    /// </summary>
    /// <returns></returns>
    [HttpGet, HttpPost, Route("GetTreeMenu")]
    public IActionResult GetTreeMenu([FromHeader] String Id, [FromHeader] String? Lng)
    {
        var result = new DGResult();

        if (Id.IsNullOrWhiteSpace())
        {
            result.Message = GetResource("请求标识不能为空", Lng);
            return result;
        }
        result.Id = Id;

        var UId = DHWeb.Identity.GetValue(ClaimTypes.Sid);

        var model = UserE.FindByID(UId.ToInt());
        if (model == null)
        {
            result.Message = GetResource("未获取到当前用户数据！", Lng);
            return result;
        }



        result.Code = StateCode.Ok;

        return result;
    }
}
