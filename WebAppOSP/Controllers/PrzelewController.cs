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

}
