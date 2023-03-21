using BibliotekaOSP.Encje;
using BibliotekaOSP.Interfejsy;
using BibliotekaOSP.ModeleDto;

namespace WebAppOSP.Services;

public class FirmyService : IFirmyService
{
    private readonly OSPDbContext dbContext;

    public FirmyService(OSPDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void UtwórzFirmę(UtwórzFirmęDto utwórzFirmęDto)
    {
        throw new NotImplementedException();
    }

    public void EdytujFirmę(int firmaId, UtwórzFirmęDto utwórzFirmęDto)
    {
        throw new NotImplementedException();
    }

    public FirmaDto PobierzFirmę(int firmaId)
    {
        throw new NotImplementedException();
    }

    public List<FirmaDto> PobierzFirmy()
    {
        throw new NotImplementedException();
    }
}
