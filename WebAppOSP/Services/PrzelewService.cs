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

    public void UtwórzPrzelew()
    {

    }
}
