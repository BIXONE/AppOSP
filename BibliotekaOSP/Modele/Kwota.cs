using BibliotekaOSP.Enumy;
using BibliotekaOSP.Narzędzia;

namespace BibliotekaOSP.Modele;

public class Kwota
{
    public decimal Wartość { get; set; }
    public Waluta Symbol { get; set; }

    public Kwota(decimal kwota, Waluta waluta = Waluta.PLN)
    {
        Wartość = NarzędziaMatematyczne.ZaokrąglijCena(kwota);
        Symbol = waluta;
    }

    public Kwota(double kwota, Waluta waluta = Waluta.PLN)
    {
        Wartość = NarzędziaMatematyczne.ZaokrąglijCena((decimal)kwota);
        Symbol = waluta;
    }

    public Kwota(float kwota, Waluta waluta = Waluta.PLN)
    {
        Wartość = NarzędziaMatematyczne.ZaokrąglijCena((decimal)kwota);
        Symbol = waluta;
    }

    public Kwota(int kwota, Waluta waluta = Waluta.PLN)
    {
        Wartość = NarzędziaMatematyczne.ZaokrąglijCena((decimal)kwota);
        Symbol = waluta;
    }

    public Kwota(uint kwota, Waluta waluta = Waluta.PLN)
    {
        Wartość = NarzędziaMatematyczne.ZaokrąglijCena((decimal)kwota);
        Symbol = waluta;
    }

    public Kwota(long kwota, Waluta waluta = Waluta.PLN)
    {
        Wartość = NarzędziaMatematyczne.ZaokrąglijCena((decimal)kwota);
        Symbol = waluta;
    }

    public Kwota(ulong kwota, Waluta waluta = Waluta.PLN)
    {
        Wartość = NarzędziaMatematyczne.ZaokrąglijCena((decimal)kwota);
        Symbol = waluta;
    }
}
