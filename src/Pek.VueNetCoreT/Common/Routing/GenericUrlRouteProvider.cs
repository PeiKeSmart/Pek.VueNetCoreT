using DH.Core.Domain.Localization;

using Pek.NCube.Routing;

namespace Pek.VueNetCoreT.Server.Common.Routing;

/// <summary>
/// 代表提供一般路由的供应商
/// </summary>
public class GenericUrlRouteProvider : BaseRouteProvider, IRouteProvider
{
    /// <summary>
    /// 获取路由提供者的优先级
    /// </summary>
    public Int32 Priority => -1000000; // 它应该是最后一条路由。 我们没有将其设置为-int.MaxValue，因此可以将其覆盖（如果需要）

    /// <summary>
    /// 注册路由
    /// </summary>
    /// <param name="endpoints">路由构造器</param>
    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        var lang = GetLanguageRoutePattern();

        // 默认路由
        var localizationSettings = LocalizationSettings.Current;
        if (localizationSettings.IsEnable) // 是否启用多语言
        {
            //endpointRouteBuilder.MapControllerRoute(
            //    name: "MuliControllerWithId",
            //    pattern: $"{lang}/{{controller}}/{{id:int}}",
            //    defaults: new { action = "Index" }
            //);

            //endpointRouteBuilder.MapControllerRoute(
            //    "MuliDefault",
            //    $"{lang}/{{controller=CubeHome}}/{{action=Index}}/{{id?}}"
            //);
        }
        endpointRouteBuilder.MapControllerRoute(
            name: "ControllerWithId",
            pattern: "{controller}/{id:int}",
            defaults: new { action = "Index" }
        );
        endpointRouteBuilder.MapControllerRoute(
            "Default",
            "{controller=CubeHome}/{action=Index}/{id?}"
        );

        var pattern = $"{lang}/";

        if (!DHSetting.Current.IsInstalled) return;

        // 通用路由（实际上路由是在 SlugRouteTransformer 中稍后处理的）
        //var genericCatalogPattern = $"{lang}/{{{PekRoutingDefaults.RouteValue.CatalogSeName}}}/{{{PekRoutingDefaults.RouteValue.SeName}}}";
        //endpointRouteBuilder.MapDynamicControllerRoute<SlugRouteTransformer>(genericCatalogPattern);

        //var genericPattern = $"{lang}/{{{PekRoutingDefaults.RouteValue.SeName}}}";
        //endpointRouteBuilder.MapDynamicControllerRoute<SlugRouteTransformer>(genericPattern);

        // 切换语言
        if (localizationSettings.IsEnable) // 是否启用多语言
        {
            endpointRouteBuilder.MapControllerRoute("MuliChangeLanguage", pattern + "changelanguage/{langid:min(0)?}",
                new { controller = "Common", action = "SetLanguage" });
            endpointRouteBuilder.MapControllerRoute("MuliChangeLang", pattern + "changelang/{id?}",
                new { controller = "Common", action = "SelectLang" });
        }
        endpointRouteBuilder.MapControllerRoute("ChangeLanguage", "changelanguage/{langid:min(0)?}",
            new { controller = "Common", action = "SetLanguage" });
        endpointRouteBuilder.MapControllerRoute("ChangeLang", "changelang/{id?}",
            new { controller = "Common", action = "SelectLang" });

        // 切换货币
        if (localizationSettings.IsEnable) // 是否启用多语言
        {
            endpointRouteBuilder.MapControllerRoute("MuliChangeCurrency", pattern + "changecurrency/{currencyid:min(0)?}",
                new { controller = "Common", action = "SetCurrency" });
            endpointRouteBuilder.MapControllerRoute("MuliChangeCurrencies", pattern + "changecurrencies/{id?}",
                new { controller = "Common", action = "SelectCurrency" });
        }
        endpointRouteBuilder.MapControllerRoute("ChangeCurrency", "changecurrency/{currencyid:min(0)?}",
            new { controller = "Common", action = "SetCurrency" });
        endpointRouteBuilder.MapControllerRoute("ChangeCurrencies", "changecurrencies/{id?}",
            new { controller = "Common", action = "SelectCurrency" });
    }
}