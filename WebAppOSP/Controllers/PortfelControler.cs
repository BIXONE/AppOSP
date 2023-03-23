using Microsoft.AspNetCore.Mvc;

namespace WebAppOSP.Controllers;

[Route("portfel")]
public class PortfelController : ControllerBase
{
    [HttpGet("{portfelId}")]
    public ActionResult WartośćPortfela([FromRoute] int portfelId)
    {
        return Ok(WartośćPortfela(portfelId).ToString());
    }
}
