using System.Reflection;

namespace BibliotekaOSP;

public class OSPMapowanie
{
    private readonly OSPDbContext dbContext;

    public OSPMapowanie(OSPDbContext dbContext)
    {
        this.dbContext = dbContext;
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

    #region Członkowie
    public Adres OdUtwórzCzłonkaDtoDoAdresu(UtwórzCzłonkaDto utwórzCzłonkaDto)
    {
        Adres adres = new();
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
            AdresSiedziby = OdAdres((from adres in dbContext.Adresy
                                     where adres.Id == członek.AdresZamieszkaniaId
                                     select adres).FirstOrDefault())
        };

        członekDto = (CzłonekDto)DomyślneMapowanieWłaściwości(członekDto, członek);

        return członekDto;
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

    public Członek OdUtwórzCzłonekDto(UtwórzCzłonkaDto utwórzCzłonekDto)
    {
        Członek członek = new();
        członek = (Członek)DomyślneMapowanieWłaściwości(członek, utwórzCzłonekDto);
        return członek;
    }
    #endregion

    public AdresDto OdAdres(Adres adres)
    {
        AdresDto adresDto = new();

        adresDto = (AdresDto)DomyślneMapowanieWłaściwości(adresDto, adres);

        return adresDto;
    }

    #region Firmy
    public Adres OdUtwórzFirmęDtoDoAdresu(UtwórzFirmęDto utwórzFirmęDto)
    {
        Adres adres = new();
        adres = (Adres)DomyślneMapowanieWłaściwości(adres, utwórzFirmęDto);
        return adres;
    }

    public Adres OdUtwórzFirmęDtoDoAdresuKorespondencji(UtwórzFirmęDto utwórzFirmęDto)
    {
        Adres adres = new()
        {
            UlicaMiasto = utwórzFirmęDto.UlicaMiastoKorespondencji,
            Numer = utwórzFirmęDto.NumerKorespondencji,
            KodPocztowy = utwórzFirmęDto.KodPocztowyKorespondencji,
            Miejscowość = utwórzFirmęDto.MiejscowośćKorespondencji
        };
        return adres;
    }

    public FirmaDto OdFirma(Firma firma)
    {
        FirmaDto firmaDto = new()
        {
            AdresSiedziby = OdAdres((from adres in dbContext.Adresy
                                     where adres.Id == firma.AdresSiedzibyId
                                     select adres).FirstOrDefault())
        };

        firmaDto = (FirmaDto)DomyślneMapowanieWłaściwości(firmaDto, firma);

        return firmaDto;
    }

    public List<FirmaDto> OdListyFirm(List<Firma> listaFirm)
    {
        List<FirmaDto> listaFirmDto = new();

        foreach (var firma in listaFirm)
        {
            listaFirmDto.Add(OdFirma(firma));
        }

        return listaFirmDto;
    }

    public Firma OdUtwórzFirmęDto(UtwórzFirmęDto utwórzFirmęDto)
    {
        Firma firma = new();
        firma = (Firma)DomyślneMapowanieWłaściwości(firma, utwórzFirmęDto);
        return firma;
    }
    #endregion

    public Portfel OdUtwórzPortfelDto(UtwórzPortfelDto utwórzPortfelDto)
    {
        Portfel portfel = new();
        portfel = (Portfel)DomyślneMapowanieWłaściwości(portfel, utwórzPortfelDto);
        return portfel;
    }

    #region Przelewy
    public Przelew OdUtwórzPrzelewDto(UtwórzPrzelewDto utwórzPrzelewDto)
    {
        Przelew przelew = new();
        przelew = (Przelew)DomyślneMapowanieWłaściwości(przelew, utwórzPrzelewDto);
        return przelew;
    }

    public PrzelewDto? OdPrzelew(Przelew przelew)
    {
        PrzelewDto przelewDto = new();
        przelewDto = (PrzelewDto)DomyślneMapowanieWłaściwości(przelewDto, przelew);
        return przelewDto;
    }

    public List<PrzelewDto> OdListyPrzelewów(List<Przelew> przelewy)
    {
        List<PrzelewDto> listaPrzelewówDto = new();

        foreach (var przelew in przelewy)
        {
            listaPrzelewówDto.Add(OdPrzelew(przelew));
        }

        return listaPrzelewówDto;
    }
    #endregion
}
