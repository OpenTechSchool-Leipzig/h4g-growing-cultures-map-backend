using Microsoft.AspNetCore.Mvc;

namespace hack4good.Web.Controllers;

public class HCController : HackController
{
    [HttpGet]
    public async Task<IActionResult> Check()
    {
        return Ok(1);
    }
}