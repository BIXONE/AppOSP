using Microsoft.AspNetCore.Mvc;

namespace WebAppOSP.Controllers;

[Route("członkowie")]
public class CzłonkowieController : ControllerBase
{
    private readonly ICzłonkowieService członkowieService;

    public CzłonkowieController(ICzłonkowieService członkowieService)
    {
        this.członkowieService = członkowieService;
    }

    [HttpGet("{członekId}")]
    public ActionResult PobierzCzłonka([FromRoute] int członekId)
    {
        var członek = członkowieService.PobierzCzłonka(członekId);
        if (członek == null)
            return NotFound();
        return Ok(członek);
    }

    [HttpGet]
    public ActionResult PobierzCzłonków()
    {
        var listaCzłonków = członkowieService.PobierzCzłonków();
        if (listaCzłonków == null)
            return NotFound();
        return Ok(listaCzłonków);
    }

    [HttpPost]
    public ActionResult UtwórzCzłonka([FromBody] UtwórzCzłonkaDto utwórzCzłonkaDto)
    {
        członkowieService.UtwórzCzłonka(utwórzCzłonkaDto);
        return Ok(utwórzCzłonkaDto);
    }

    [HttpPut("{członekId}")]
    public ActionResult EdytujCzłonka([FromRoute] int członekId, [FromBody] UtwórzCzłonkaDto utwórzCzłonkaDto)
    {
        członkowieService.EdytujCzłonka(członekId, utwórzCzłonkaDto);
        return Ok(utwórzCzłonkaDto);
    }
}
