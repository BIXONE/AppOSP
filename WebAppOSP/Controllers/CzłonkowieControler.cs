using Microsoft.AspNetCore.Mvc;

namespace WebAppOSP.Controllers;

[Route("członkowie")]
public class CzłonkowieControler : ControllerBase
{
    private readonly ICzłonkowieService członkowieService;

    public CzłonkowieControler(ICzłonkowieService członkowieService)
    {
        this.członkowieService = członkowieService;
    }

    [HttpGet("{id}")]
    public ActionResult PobierzCzłonka([FromRoute] int id)
    {
        var członek = członkowieService.PobierzCzłonka(id);
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
}
