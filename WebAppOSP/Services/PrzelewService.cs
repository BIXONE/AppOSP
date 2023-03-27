namespace WebAppOSP.Services;

public class PrzelewService : IPrzelewService
{
    private readonly OSPDbContext dbContext;
    private readonly OSPMapowanie mapowanie;

    public PrzelewService(OSPDbContext dbContext)
    {
        this.dbContext = dbContext;
        mapowanie = new(dbContext);
    }

    public bool? EdytujPrzelew(int przelewId, UtwórzPrzelewDto utwórzPrzelewDto)
    {
        Przelew? przelew = (from przel in dbContext.Przelewy
                            where przel.Id == przelewId
                            select przel).FirstOrDefault();

        if (przelew == null)
            return null;

        przelew = mapowanie.OdUtwórzPrzelewDto(utwórzPrzelewDto);
        dbContext.SaveChanges();
        return true;
    }

    public PrzelewDto? PobierzPrzelew(int przelewId)
    {
        Przelew? przelew = (from przel in dbContext.Przelewy
                           where przel.Id == przelewId
                           select przel).FirstOrDefault();

        if (przelew == null)
            return null;

        PrzelewDto przelewDto = mapowanie.OdPrzelew(przelew);

        return przelewDto;
    }

    public List<PrzelewDto> PobierzPrzelewyPoDacieWgPrzelewu(DateTime odKiedy, DateTime doKiedy, int portfelId)
    {
        List<Przelew> listaPrzelewów = (from przelew in dbContext.Przelewy
                                        where przelew.PortfelId == portfelId &&
                                        przelew.DataZlecenia >= odKiedy && przelew.DataZlecenia <= doKiedy
                                        select przelew).ToList();

        List<PrzelewDto> listaPrzelewówDto = mapowanie.OdListyPrzelewów(listaPrzelewów);

        return listaPrzelewówDto;
    }

    public List<PrzelewDto> PobierzWszystkiePrzelewyWgPortfela(int portfelId)
    {
        List<Przelew> listaPrzelewów = (from przelew in dbContext.Przelewy
                                        where przelew.PortfelId == portfelId
                                        select przelew).ToList();

        List<PrzelewDto> listaPrzelewówDto = mapowanie.OdListyPrzelewów(listaPrzelewów);

        return listaPrzelewówDto;
    }

    public bool? UsuńPrzelew(int przelewId)
    {
        Przelew? przelew = (from przel in dbContext.Przelewy
                            where przelewId == przel.Id && przel.Blokada == false
                            select przel).FirstOrDefault();
        if (przelew == null)
            return null;

        przelew.Blokada = true;
        dbContext.SaveChanges();
        return true;
    }

    public void UtwórzPrzelew(UtwórzPrzelewDto utwórzPrzelewDto)
    {
        Przelew przelew = mapowanie.OdUtwórzPrzelewDto(utwórzPrzelewDto);
        dbContext.Przelewy.Add(przelew);
        dbContext.SaveChanges();
    }
}
