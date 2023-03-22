namespace WebAppOSP.Services;

public class CzłonkowieService : ICzłonkowieService
{
    private readonly OSPDbContext dbContext;
    private readonly OSPMapowanie mapowanie;

    public CzłonkowieService(OSPDbContext dbContext)
    {
        this.dbContext = dbContext;
        mapowanie = new(dbContext);
    }

    public void UtwórzCzłonka(UtwórzCzłonkaDto utwórzCzłonkaDto)
    {
        Adres adresKorespondencji = new();
        Adres adresZamieszkania = mapowanie.OdUtwórzCzłonkaDtoDoAdresu(utwórzCzłonkaDto);
        dbContext.Adresy.Add(adresZamieszkania);
        if (utwórzCzłonkaDto.czyJestAdresKorespondencji == true)
        {
            adresKorespondencji = mapowanie.OdUtwórzCzłonkaDtoDoAdresuKorespondencji(utwórzCzłonkaDto);
            dbContext.Adresy.Add(adresKorespondencji);
        }
        dbContext.SaveChanges();

        Członek członek = mapowanie.OdUtwórzCzłonekDto(utwórzCzłonkaDto);
        członek.AdresZamieszkaniaId = adresZamieszkania.Id;
        if (utwórzCzłonkaDto.czyJestAdresKorespondencji == true)
            członek.AdresKorespondencjiId = adresKorespondencji.Id;
        else
            członek.AdresKorespondencjiId = adresZamieszkania.Id;
        dbContext.Członkowie.Add(członek);
        dbContext.SaveChanges();
    }

    public bool EdytujCzłonka(int członekId, UtwórzCzłonkaDto utwórzCzłonkaDto)
    {
        Członek? członek = (from cz in dbContext.Członkowie
                            where cz.Id == członekId
                            select cz).FirstOrDefault();
        if (członek == null)
            return false;

        Adres? adresKorespondencji = new();
        bool czyByłAdresKorespondencji = członek.czyJestAdresKorespondencji;

        if (utwórzCzłonkaDto.czyJestAdresKorespondencji == true && czyByłAdresKorespondencji == false)
        {
            adresKorespondencji = mapowanie.OdUtwórzCzłonkaDtoDoAdresuKorespondencji(utwórzCzłonkaDto);
            dbContext.Adresy.Add(adresKorespondencji);
            dbContext.SaveChanges();
        }
        else if (utwórzCzłonkaDto.czyJestAdresKorespondencji == false && czyByłAdresKorespondencji == true)
        {
            adresKorespondencji = (from adr in dbContext.Adresy
                                   where adr.Id == członek.AdresKorespondencjiId
                                   select adr).FirstOrDefault();
            if (adresKorespondencji == null)
                return false;

            dbContext.Remove(adresKorespondencji); 
            dbContext.SaveChanges();
        }
        else if (utwórzCzłonkaDto.czyJestAdresKorespondencji == true && czyByłAdresKorespondencji == true)
        {
            adresKorespondencji = (from adr in dbContext.Adresy
                                   where adr.Id == członek.AdresKorespondencjiId
                                   select adr).FirstOrDefault();
            if (adresKorespondencji == null)
                return false;

            adresKorespondencji = mapowanie.OdUtwórzCzłonkaDtoDoAdresuKorespondencji(utwórzCzłonkaDto);
        }

        Adres? adresZamieszkania = (from adr in dbContext.Adresy
                                    where adr.Id == członek.AdresZamieszkaniaId
                                    select adr).FirstOrDefault();
        if (adresZamieszkania == null)
            return false;

        adresZamieszkania = mapowanie.OdUtwórzCzłonkaDtoDoAdresu(utwórzCzłonkaDto);
        członek = mapowanie.OdUtwórzCzłonekDto(utwórzCzłonkaDto);
        członek.AdresZamieszkaniaId = adresZamieszkania.Id;
        if (utwórzCzłonkaDto.czyJestAdresKorespondencji == true)
            członek.AdresKorespondencjiId = adresKorespondencji.Id;
        else
            członek.AdresKorespondencjiId = adresZamieszkania.Id;

        dbContext.SaveChanges();
        return true;
    }

    public CzłonekDto? PobierzCzłonka(int członekId)
    {
        Członek? członek = (from cz in dbContext.Członkowie
                            where cz.Id == członekId
                            select cz).FirstOrDefault();
        if (członek == null)
            return null;

        var członekDto = mapowanie.OdCzłonek(członek);
        return członekDto;
    }

    public List<CzłonekDto>? PobierzCzłonków()
    {
        List<Członek> członkowie = (from członek in dbContext.Członkowie
                                    select członek).ToList();
        if (członkowie == null)
            return null;

        var listaCzłonków = mapowanie.OdListyCzłonków(członkowie);
        return listaCzłonków;
    }
}
