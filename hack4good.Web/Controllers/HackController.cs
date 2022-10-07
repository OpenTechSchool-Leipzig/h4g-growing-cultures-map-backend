using Microsoft.AspNetCore.Mvc;

namespace hack4good.Web.Controllers;

[Controller]
[Route("[controller]/[action]")]
public abstract class HackController : Controller
{
}