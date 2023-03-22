using Microsoft.AspNetCore.Mvc;

namespace WebAppOSP.Controllers;

[Route("firmy")]
public class FirmyControler : ControllerBase
{
    private readonly IFirmyService firmyService;

    public FirmyControler(IFirmyService firmyService)
    {
        this.firmyService = firmyService;
    }

    [HttpGet("{firmaId}")]
    public ActionResult PobierzFirmę([FromRoute] int firmaId)
    {
        var firma = firmyService.PobierzFirmę(firmaId);
        if (firma == null)
            return NotFound();
        return Ok(firma);
    }

    [HttpGet]
    public ActionResult PobierzFirmy()
    {
        var listaFirm = firmyService.PobierzFirmy();
        if (listaFirm == null)
            return NotFound();
        return Ok(listaFirm);
    }

    [HttpPost]
    public ActionResult UtwórzFirmę([FromBody] UtwórzFirmęDto utwórzFirmęDto)
    {
        firmyService.UtwórzFirmę(utwórzFirmęDto);
        return Ok(utwórzFirmęDto);
    }

    [HttpPut("{firmaId}")]
    public ActionResult EdytujFirmę([FromRoute] int firmaId, [FromBody] UtwórzFirmęDto utwórzFirmęDto)
    {
        firmyService.EdytujFirmę(firmaId, utwórzFirmęDto);
        return Ok(utwórzFirmęDto);
    }
}
