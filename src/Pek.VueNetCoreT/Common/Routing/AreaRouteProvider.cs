using DH.Core.Domain.Localization;

using Pek.NCube.Routing;

namespace Pek.VueNetCoreT.Server.Common.Routing;

/// <summary>
/// 代表提供区域路由的供应商
/// </summary>
public class AreaRouteProvider : BaseRouteProvider, IRouteProvider
{
    /// <summary>
    /// 获取路由提供者的优先级
    /// </summary>
    public Int32 Priority => 1;

    /// <summary>
    /// 注册路由
    /// </summary>
    /// <param name="endpoints">路由构造器</param>
    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        if (!DHSetting.Current.IsInstalled) return;

        var lang = GetLanguageRoutePattern();

        // 对路由进行重新排序，以便最常用的路由排在最前面。 它可以提高性能
        var UrlSuffix = String.Empty;
        if (DHSetting.Current.IsAllowUrlSuffix)
        {
            UrlSuffix = ".{urlsuffix:suffix=" + DHSetting.Current.UrlSuffix + "}";
        }

        var pattern = $"{lang}/";
        var localizationSettings = LocalizationSettings.Current;

        // 默认区域路由
        endpointRouteBuilder.MapControllerRoute(
            name: "AreasWidthId",
            pattern: "{area:exists}/{controller}/{id:int}",
            defaults: new { action = "Index" }
        );
        endpointRouteBuilder.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    }
}