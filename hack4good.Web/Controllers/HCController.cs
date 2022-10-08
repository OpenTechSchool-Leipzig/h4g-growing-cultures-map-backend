using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hack4good.Web.Controllers;

public class HCController : HackController
{
    [HttpGet]
    [SwaggerOperation("для внутреннего использования")]
    public async Task<IActionResult> Check()
    {
        return Ok(1);
    }
}