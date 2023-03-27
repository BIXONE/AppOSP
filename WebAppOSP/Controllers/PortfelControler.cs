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

    [HttpPost]
    public ActionResult UtwórzPortfel([FromBody] UtwórzCzłonkaDto utwórzCzłonkaDto)
    {
        UtwórzPortfel(utwórzCzłonkaDto);
        return Ok();
    }

    [HttpPut("{portfelId}")]
    public ActionResult EdytujPortfel([FromRoute] int portfelId, [FromBody] UtwórzCzłonkaDto utwórzCzłonkaDto)
    {
        EdytujPortfel(portfelId, utwórzCzłonkaDto);
        return Ok();
    }

    [HttpDelete("{portfelId}")]
    public ActionResult UsuńPortfel([FromRoute] int portfelId)
    {
        UsuńPortfel(portfelId);
        return Ok();
    }

}
