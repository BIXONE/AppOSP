namespace WebAppOSP.Services;

public class FirmyService : IFirmyService
{
    private readonly OSPDbContext dbContext;
    private readonly OSPMapowanie mapowanie;

    public FirmyService(OSPDbContext dbContext)
    {
        this.dbContext = dbContext;
        mapowanie = new(dbContext);
    }

    public void UtwórzFirmę(UtwórzFirmęDto utwórzFirmęDto)
    {
        Adres adresKorespondencji = new();
        Adres adresSiedziby = mapowanie.OdUtwórzFirmęDtoDoAdresu(utwórzFirmęDto);
        dbContext.Adresy.Add(adresSiedziby);
        if (utwórzFirmęDto.czyJestAdresKorespondencji == true)
        {
            adresKorespondencji = mapowanie.OdUtwórzFirmęDtoDoAdresuKorespondencji(utwórzFirmęDto);
            dbContext.Adresy.Add(adresKorespondencji);
        }
        dbContext.SaveChanges();

        Firma firma = mapowanie.OdUtwórzFirmęDto(utwórzFirmęDto);
        firma.AdresSiedzibyId = adresSiedziby.Id;
        if (utwórzFirmęDto.czyJestAdresKorespondencji == true)
            firma.AdresKorespondencjiId = adresKorespondencji.Id;
        else
            firma.AdresKorespondencjiId = adresSiedziby.Id;
        dbContext.Firmy.Add(firma);
        dbContext.SaveChanges();
    }

    public bool EdytujFirmę(int firmaId, UtwórzFirmęDto utwórzFirmęDto)
    {
        Firma? firma = (from fir in dbContext.Firmy
                            where fir.Id == firmaId
                            select fir).FirstOrDefault();
        if (firma == null)
            return false;

        Adres? adresKorespondencji = new();
        bool czyByłAdresKorespondencji = firma.czyJestAdresKorespondencji;

        if (utwórzFirmęDto.czyJestAdresKorespondencji == true && czyByłAdresKorespondencji == false)
        {
            adresKorespondencji = mapowanie.OdUtwórzFirmęDtoDoAdresuKorespondencji(utwórzFirmęDto);
            dbContext.Adresy.Add(adresKorespondencji);
            dbContext.SaveChanges();
        }
        else if (utwórzFirmęDto.czyJestAdresKorespondencji == false && czyByłAdresKorespondencji == true)
        {
            adresKorespondencji = (from adr in dbContext.Adresy
                                   where adr.Id == firma.AdresKorespondencjiId
                                   select adr).FirstOrDefault();
            if (adresKorespondencji == null)
                return false;

            dbContext.Remove(adresKorespondencji);
            dbContext.SaveChanges();
        }
        else if (utwórzFirmęDto.czyJestAdresKorespondencji == true && czyByłAdresKorespondencji == true)
        {
            adresKorespondencji = (from adr in dbContext.Adresy
                                   where adr.Id == firma.AdresKorespondencjiId
                                   select adr).FirstOrDefault();
            if (adresKorespondencji == null)
                return false;

            adresKorespondencji = mapowanie.OdUtwórzFirmęDtoDoAdresuKorespondencji(utwórzFirmęDto);
        }

        Adres? adresSiedziby = (from adr in dbContext.Adresy
                                    where adr.Id == firma.AdresSiedzibyId
                                    select adr).FirstOrDefault();
        if (adresSiedziby == null)
            return false;

        adresSiedziby = mapowanie.OdUtwórzFirmęDtoDoAdresu(utwórzFirmęDto);
        firma = mapowanie.OdUtwórzFirmęDto(utwórzFirmęDto);
        firma.AdresSiedzibyId = adresSiedziby.Id;
        if (utwórzFirmęDto.czyJestAdresKorespondencji == true)
            firma.AdresKorespondencjiId = adresKorespondencji.Id;
        else
            firma.AdresKorespondencjiId = adresSiedziby.Id;

        dbContext.SaveChanges();
        return true;
    }

    public FirmaDto PobierzFirmę(int firmaId)
    {
        Firma? firma = (from cz in dbContext.Firmy
                          where cz.Id == firmaId
                          select cz).FirstOrDefault();
        if (firma == null)
            return null;

        var firmaDto = mapowanie.OdFirma(firma);
        return firmaDto;
    }

    public List<FirmaDto> PobierzFirmy()
    {
        List<Firma> firmy = (from firma in dbContext.Firmy
                             select firma).ToList();
        if (firmy == null)
            return null;

        var listaFirm = mapowanie.OdListyFirm(firmy);
        return listaFirm;
    }
}
