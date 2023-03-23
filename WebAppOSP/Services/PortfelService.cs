namespace WebAppOSP.Services;

public class PortfelService : IPortfelService
{
    private readonly OSPDbContext dbContext;
    private readonly OSPMapowanie mapowanie;

    public PortfelService(OSPDbContext dbContext)
    {
        this.dbContext = dbContext;
        mapowanie = new(dbContext);
    }

    public bool? EdytujPortfel(int portfelId, UtwórzPortfelDto utwórzPortfel)
    {
        throw new NotImplementedException();
    }

    public bool? UsuńPortfel(int portfelId)
    {
        Portfel? portfel = (from port in dbContext.Portfele
                          where portfelId == port.Id && port.Blokada == false
                          select port).FirstOrDefault();
        if (portfel == null)
            return null;

        portfel.Blokada = true;
        dbContext.SaveChanges();
        return true;
    }

    public void UtwórzPortfel(UtwórzPortfelDto utwórzPortfel)
    {
        throw new NotImplementedException();
    }

    public Kwota WartośćPortfela(int portfelId)
    {
        Kwota wartośćPortfela = new(0);

        List<Przelew> przelewy = (from przelew in dbContext.Przelewy
                                  where przelew.PortfelId == portfelId
                                  select przelew).ToList();

        foreach (var przelew in przelewy)
        {
            wartośćPortfela += przelew.Kwota;
        }
        Console.WriteLine(wartośćPortfela.ToString());
        return wartośćPortfela;
    }
}
