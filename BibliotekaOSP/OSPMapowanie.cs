using System.Reflection;

namespace BibliotekaOSP;

public class OSPMapowanie
{
    private readonly OSPDbContext dbContext;

    public OSPMapowanie(OSPDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Adres OdUtwórzCzłonkaDtoDoAdresu(UtwórzCzłonkaDto utwórzCzłonkaDto)
    {
        Adres adres = new Adres();
        adres = (Adres)DomyślneMapowanieWłaściwości(adres, utwórzCzłonkaDto);
        return adres;
    }

    public Adres OdUtwórzCzłonkaDtoDoAdresuKorespondencji(UtwórzCzłonkaDto utwórzCzłonkaDto)
    {
        Adres adres = new()
        {
            UlicaMiasto = utwórzCzłonkaDto.UlicaMiastoKorespondencji,
            Numer = utwórzCzłonkaDto.NumerKorespondencji,
            KodPocztowy = utwórzCzłonkaDto.KodPocztowyKorespondencji,
            Miejscowość = utwórzCzłonkaDto.MiejscowośćKorespondencji
        };
        return adres;
    }

    public CzłonekDto OdCzłonek(Członek członek)
    {
        CzłonekDto członekDto = new()
        {
            AdresZamieszkania = OdAdres((from adres in dbContext.Adresy
                                         where adres.Id == członek.AdresZamieszkaniaId
                                         select adres).FirstOrDefault())
        };

        członekDto = (CzłonekDto)DomyślneMapowanieWłaściwości(członekDto, członek);

        return członekDto;
    }

    /// <summary>
    /// Mapuje właściwości po nazwie jeżeli nie zostały wcześniej przypisane do niego żadne wartości
    /// </summary>
    /// <param name="obiektMapowany">Obiekt na który mapujemy właściwości</param>
    /// <param name="obiektPierwotny">Obiekt z którego mapujemy właściwości</param>
    /// <returns>Obiekt mapowany</returns>
    private object? DomyślneMapowanieWłaściwości(object obiektMapowany, object obiektPierwotny)
    {
        PropertyInfo[] propertyObiektMapowany = obiektMapowany.GetType().GetProperties();
        PropertyInfo[] propertyObiektPierwotny = obiektPierwotny.GetType().GetProperties();

        foreach (var property in propertyObiektMapowany)
        {
            if (property.GetValue(obiektMapowany) == null)
            {
                PropertyInfo? propertyInfoZmienna = (from cz in propertyObiektPierwotny
                                                     where property.Name == cz.Name
                                                     select cz).FirstOrDefault();
                if (propertyInfoZmienna != null)
                    property.SetValue(obiektMapowany, propertyInfoZmienna.GetValue(obiektPierwotny));
                else
                    property.SetValue(obiektMapowany, null);
            }
        }

        return obiektMapowany;
    }

    public List<CzłonekDto> OdListyCzłonków(List<Członek> listaCzłonków)
    {
        List<CzłonekDto> listaCzłonkówDto = new();

        foreach (var członek in listaCzłonków)
        {
            listaCzłonkówDto.Add(OdCzłonek(członek));
        }

        return listaCzłonkówDto;
    }

    public AdresDto OdAdres(Adres adres)
    {
        AdresDto adresDto = new();

        adresDto = (AdresDto)DomyślneMapowanieWłaściwości(adresDto, adres);

        return adresDto;
    }

    public Członek OdUtwórzCzłonekDto(UtwórzCzłonkaDto utwórzCzłonekDto)
    {
        Członek członek = new()
        {
            czyJestAdresKorespondencji = utwórzCzłonekDto.InnyAdresKorespondencji
        };
        członek = (Członek)DomyślneMapowanieWłaściwości(członek, utwórzCzłonekDto);
        return członek;
    }
}
