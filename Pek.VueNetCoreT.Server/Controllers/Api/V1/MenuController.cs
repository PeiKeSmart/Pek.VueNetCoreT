using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Pek.NCube;

namespace Pek.VueNetCoreT.Server.Controllers.Api.V1;

[Authorize("jwt")]
public class MenuController : PekControllerBaseX
{
    public IActionResult Index()
    {
        return View();
    }
}
