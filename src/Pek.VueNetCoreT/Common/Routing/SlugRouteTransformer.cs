using DH.Entity;

using Microsoft.AspNetCore.Mvc.Routing;

using NewLife;
using NewLife.Log;

using Pek.Events;
using Pek.NCube.Events;
using Pek.NCube.Routing;
using Pek.Webs;

namespace Pek.VueNetCoreT.Server.Common.Routing;

/// <summary>
/// slug路由转换器
/// </summary>
public class SlugRouteTransformer : DynamicRouteValueTransformer
{
    protected readonly IEventPublisher _eventPublisher;
    protected readonly IWebHelper _webHelper;

    public SlugRouteTransformer(IEventPublisher eventPublisher, IWebHelper webHelper)
    {
        _eventPublisher = eventPublisher;
        _webHelper = webHelper;
    }

    public override async ValueTask<RouteValueDictionary?> TransformAsync(Microsoft.AspNetCore.Http.HttpContext httpContext, RouteValueDictionary routeValues)
    {
        // 静态文件不处理
        if (_webHelper.IsStaticResource()) return new RouteValueDictionary(routeValues);

        XTrace.WriteLine($"进来了么？SlugRouteTransformer");

        // 获取用于动作选择的转换值
        var values = new RouteValueDictionary(routeValues);
        if (values is null)
            return values;

        if (!values.TryGetValue(PekRoutingDefaults.RouteValue.SeName, out var slugValue))
            return values;

        var slug = slugValue as string;
        XTrace.WriteLine($"获取到的Slug是多少：{slug}");

        var UrlSuffix = DHSetting.Current.IsAllowUrlSuffix ? DHSetting.Current.UrlSuffix : "";
        if (UrlSuffix.IsNotNullAndWhiteSpace())
            slug = slug?.TrimEnd(UrlSuffix);

        // 通过 URL 别名查找记录
        if (UrlRecord.FindBySlug(slug?.ToString()) is not UrlRecord urlRecord)
            return values;

        // 允许第三方处理程序通过找到的 URL 记录选择一个操作
        var routingEvent = new GenericRoutingEvent(httpContext, values, urlRecord);
        await _eventPublisher.PublishAsync(routingEvent);
        if (routingEvent.Handled)
            return values;

        // 最后，仅通过 URL 记录选择一个操作  必须按下面的方式走
        //values["controller"] = "CubeHome"; // 设置目标控制器
        //values["action"] = "Index"; // 设置目标动作


        return values;
    }
}
