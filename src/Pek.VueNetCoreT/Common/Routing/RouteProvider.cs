using DH.Core.Domain.Localization;

using Pek.NCube.Routing;

namespace Pek.VueNetCoreT.Server.Common.Routing;

public class RouteProvider : BaseRouteProvider, IRouteProvider
{
    /// <summary>
    /// 注册路由
    /// </summary>
    /// <param name="endpointRouteBuilder">路由构造器</param>
    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        var lang = GetLanguageRoutePattern();

        // 对路由进行重新排序，以便最常用的路由排在最前面。 它可以提高性能
        var UrlSuffix = String.Empty;
        if (DHSetting.Current.IsAllowUrlSuffix)
        {
            UrlSuffix = $".{{{PekRoutingDefaults.RouteValue.UrlSuffix}:{PekRoutingDefaults.SuffixParameterTransformer}={DHSetting.Current.UrlSuffix}}}";
        }

        var pattern = $"{lang}/";
        var localizationSettings = LocalizationSettings.Current;

        // 首页
        if (localizationSettings.IsEnable) // 是否启用多语言
            endpointRouteBuilder.MapControllerRoute("MuliHomepage", pattern,
                     new { controller = "CubeHome", action = "Index" });
        endpointRouteBuilder.MapControllerRoute("Homepage", "",
            new { controller = "CubeHome", action = "Index" });

        // 单页
        if (localizationSettings.IsEnable) // 是否启用多语言
            endpointRouteBuilder.MapControllerRoute("MuliAbout", pattern + "About/{Code}" + UrlSuffix,
                new { controller = "SingleArticle", action = "Index" });
        endpointRouteBuilder.MapControllerRoute("About", "About/{Code}" + UrlSuffix,
                new { controller = "SingleArticle", action = "Index" });

        // 注册
        if (localizationSettings.IsEnable) // 是否启用多语言
            endpointRouteBuilder.MapControllerRoute("MuliRegister", pattern + "Register" + UrlSuffix,
               new { controller = "Register", action = "Index" });
        endpointRouteBuilder.MapControllerRoute("Register", "Register" + UrlSuffix,
                new { controller = "Register", action = "Index" });

        // 登录
        if (localizationSettings.IsEnable) // 是否启用多语言
            endpointRouteBuilder.MapControllerRoute("MuliLogin", pattern + "Login" + UrlSuffix,
                new { controller = "Login", action = "Index" });
        endpointRouteBuilder.MapControllerRoute("Login", "Login" + UrlSuffix,
                new { controller = "Login", action = "Index" });

        // 找回密码
        if (localizationSettings.IsEnable) // 是否启用多语言
            endpointRouteBuilder.MapControllerRoute("MuliFindPwd", pattern + "FindPwd" + UrlSuffix,
                new { controller = "FindPwd", action = "Index" });
        endpointRouteBuilder.MapControllerRoute("Login", "FindPwd" + UrlSuffix,
                new { controller = "FindPwd", action = "Index" });

        // 帮助中心首页
        if (localizationSettings.IsEnable) // 是否启用多语言
            endpointRouteBuilder.MapControllerRoute("MuliHelpHome", pattern + "Help" + UrlSuffix,
                new { controller = "Help", action = "Index" });
        endpointRouteBuilder.MapControllerRoute("Login", "Help" + UrlSuffix,
                new { controller = "Help", action = "Index" });

    }

    /// <summary>
    /// 获取路由提供者的优先级
    /// </summary>
    public int Priority => -1;
}
