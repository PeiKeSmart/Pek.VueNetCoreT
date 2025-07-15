using Pek.Infrastructure;
using Pek.VirtualFileSystem;

namespace Pek.VueNetCoreT.Server;

/// <summary>
/// 表示应用程序启动时配置服务和中间件的对象
/// </summary>
public class DHStartup : IPekStartup
{
    /// <summary>
    /// 配置添加的中间件的使用
    /// </summary>
    /// <param name="application"></param>
    public void Configure(IApplicationBuilder application)
    {

    }

    /// <summary>
    /// 将区域路由写入数据库
    /// </summary>
    public void ConfigureArea()
    {
        //AreaBase.SetRoute<HomeController>(AdminArea.AreaName);
    }

    /// <summary>
    /// 添加并配置任何中间件
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <param name="webHostEnvironment"></param>
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment? webHostEnvironment)
    {
        DHSetting.Current.ServerToken = "tRdUsTfy4VINPOi9";
        DHSetting.Current.IsCheckApiSignature = true;
        DHSetting.Current.Save();
    }

    /// <summary>
    /// 注册路由
    /// </summary>
    /// <param name="endpoints">路由生成器</param>
    public void UseDHEndpoints(IEndpointRouteBuilder endpoints)
    {
    }

    /// <summary>
    /// 配置虚拟文件系统
    /// </summary>
    /// <param name="options"></param>
    public void ConfigureVirtualFileSystem(DHVirtualFileSystemOptions options)
    {
        options.FileSets.AddEmbedded<DHStartup>(typeof(DHStartup).Namespace);
        // options.FileSets.Add(new EmbeddedFileSet(item.Assembly, item.Namespace));
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
    /// <exception cref="NotImplementedException"></exception>
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
    /// 处理数据
    /// </summary>
    public void ProcessData()
    {
    }

    /// <summary>
    /// 获取此启动配置实现的顺序
    /// </summary>
    public Int32 StartupOrder => 101; //常见服务应在错误处理程序之后加载

    /// <summary>
    /// 获取此启动配置实现的顺序。主要针对ConfigureMiddleware、UseRouting前执行的数据、UseAuthentication或者UseAuthorization后面 Endpoints前执行的数据
    /// </summary>
    public Int32 ConfigureOrder => 0;
}