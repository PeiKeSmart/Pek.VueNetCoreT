using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetTreeMenu()
    {
        var result = new DGResult();

        result.Code = StateCode.Ok;

        return result;
    }
}
