using Pek.Swagger;

namespace Pek.VueNetCoreT.Server.Controllers.Api.V1;

public class Versions : IDHSwagger
{

    public ApiVersions ApiVersions { get; set; } = ApiVersions.V1;

    public String Description { get; set; } = "<br /><strong>备注:</strong> 创建于2025-07-09。";
}