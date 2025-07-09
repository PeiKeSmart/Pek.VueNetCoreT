using DH.Core.Domain.Localization;
using DH.Entity;

using Pek.Infrastructure;
using Pek.VirtualFileSystem;
using Pek.VueNetCoreT.Server.Common.Routing;

namespace Pek.VueNetCoreT.Server.Common;

public partial class DHStartup : IPekStartup
{
    /// <summary>
    /// 配置添加的中间件的使用
    /// </summary>
    /// <param name="application">用于配置应用程序的请求管道的生成器</param>
    public void Configure(IApplicationBuilder application)
    {
        //XTrace.WriteLine($"Configure进来了");

        var site = SiteInfo.FindDefault();
        if (site == null)
        {
            site = new SiteInfo
            {
                SiteName = "工具网",
                SeoTitle = "工具网",
                SeoKey = "工具网",
                SeoDescribe = "工具网"
            };
            site.Insert();
        }

        var sitemap = CronJob.FindByName("Sitemap");
        if (sitemap != null)
        {
            sitemap.Enable = false;
            sitemap.Update();
        }
    }

    /// <summary>
    /// 添加并配置任何中间件
    /// </summary>
    /// <param name="services">服务描述符集合</param>
    /// <param name="configuration">应用程序的配置</param>
    /// <param name="webHostEnvironment"></param>
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        services.AddScoped<SlugRouteTransformer>();  // slug路由转换

        //XTrace.WriteLine($"ConfigureServices进来了");
        DHSetting.Current.IsAllowUrlSuffix = true;
        DHSetting.Current.IsInstalled = true;

        DHSetting.Current.IsAlertOrCheckCode = 2;
        DHSetting.Current.AdminArea = "Biz";
        DHSetting.Current.CaptChaUrl = "/CaptCha/GetCheckCode";
        DHSetting.Current.SitemapXmlEnabled = true;
        DHSetting.Current.StartTime = DateTime.Now;
        DHSetting.Current.PaswordStrength = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,32}$";
        DHSetting.Current.UserCenterUrl = "~/Member";

        DHSetting.Current.Save();

        LocalizationSettings.Current.AutomaticallyDetectLanguage = true;
        LocalizationSettings.Current.Save();

        // 验证码
        // 内存缓存
        services.AddCaptcha(configuration);

        //var content = "Data".AsDirectory();
        //// 下载区域数据
        //var RegionPath = "Data/Regions.db".GetFullPath();
        //if (!RegionPath.AsFile().Exists)
        //{
        //    ThreadPool.QueueUserWorkItem(async s =>
        //    {
        //        await DHWeb.DownloadLinkAndExtract("http://x.deng-hao.com/", "3-Regions-20221005.zip", content.FullName, true);
        //    });
        //}

    }

    /// <summary>
    /// 配置虚拟文件系统
    /// </summary>
    /// <param name="options">虚拟文件配置</param>
    public void ConfigureVirtualFileSystem(DHVirtualFileSystemOptions options)
    {
    }

    /// <summary>
    /// 注册路由
    /// </summary>
    /// <param name="endpoints">路由生成器</param>
    public void UseDHEndpoints(IEndpointRouteBuilder endpoints)
    {
    }

    /// <summary>
    /// 将区域路由写入数据库
    /// </summary>
    public void ConfigureArea()
    {

    }

    /// <summary>
    /// 调整菜单
    /// </summary>
    public void ChangeMenu()
    {

    }

    /// <summary>
    /// 升级处理逻辑
    /// </summary>
    public void Update()
    {

    }

    /// <summary>
    /// 配置使用添加的中间件
    /// </summary>
    /// <param name="application">用于配置应用程序的请求管道的生成器</param>
    public void ConfigureMiddleware(IApplicationBuilder application)
    {
    }

    /// <summary>
    /// UseRouting前执行的数据
    /// </summary>
    /// <param name="application"></param>
    public void BeforeRouting(IApplicationBuilder application)
    {
    }

    /// <summary>
    /// UseAuthentication或者UseAuthorization后面 Endpoints前执行的数据
    /// </summary>
    /// <param name="application"></param>
    public void AfterAuth(IApplicationBuilder application)
    {
    }

    /// <summary>
    /// 数据处理方法，通常用于处理数据或执行其他操作
    /// </summary>
    public void ProcessData()
    {
    }

    /// <summary>
    /// 获取此启动配置实现的顺序
    /// </summary>
    public int StartupOrder => 999; //常见服务应在错误处理程序之后加载

    /// <summary>
    /// 获取此启动配置实现的顺序。主要针对ConfigureMiddleware、UseRouting前执行的数据、UseAuthentication或者UseAuthorization后面 Endpoints前执行的数据
    /// </summary>
    public int ConfigureOrder => 200;
}