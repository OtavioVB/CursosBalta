using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Balta.Areas;

[Authorize]
public class ModuloController : Controller
{
    [AllowAnonymous]
    [Route("{page=Home}")]
    public IActionResult Index()
    {
        return View();
    }
}
