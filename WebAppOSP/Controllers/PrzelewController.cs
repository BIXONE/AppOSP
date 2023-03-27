using Microsoft.AspNetCore.Mvc;

namespace WebAppOSP.Controllers;

[Route("przelew")]
public class PrzelewController : ControllerBase
{
    private readonly IFirmyService firmyService;

    public PrzelewController(IFirmyService firmyService)
    {
        this.firmyService = firmyService;
    }

    [HttpGet("{przelewId}")]
    public ActionResult PobierzPrzelew([FromRoute] int przelewId)
    {
        return Ok(PobierzPrzelew(przelewId));
    }

    [HttpGet("/portfel/{portfelId}")]
    public ActionResult PobierzWszystkiePrzelewyWgPortfela([FromRoute] int portfelId)
    {
        return Ok(PobierzWszystkiePrzelewyWgPortfela(portfelId));
    }

    [HttpGet("{portfelId}/{odKiedy}/{doKiedy}")]
    public ActionResult PobierzPrzelewyPoDacieWgPrzelewu([FromRoute] DateTime odKiedy, [FromRoute] DateTime doKiedy, [FromRoute] int portfelId)
    {
        return Ok(PobierzPrzelewyPoDacieWgPrzelewu(odKiedy, doKiedy, portfelId));
    }

    [HttpDelete("{przelewId}")]
    public ActionResult UsuńPrzelew([FromRoute] int przelewId)
    {
        UsuńPrzelew(przelewId);
        return Ok();
    }

    [HttpPut("{przelewId}")]
    public ActionResult EdytujPrzelew([FromRoute] int przelewId, [FromBody] UtwórzPrzelewDto utwórzPrzelewDto)
    {
        EdytujPrzelew(przelewId, utwórzPrzelewDto);
        return Ok();
    }

    [HttpPost]
    public ActionResult UtwórzPprzelew([FromBody] UtwórzPrzelewDto utwórzPrzelewDto)
    {
        UtwórzPprzelew(utwórzPrzelewDto);
        return Ok();
    }
}
