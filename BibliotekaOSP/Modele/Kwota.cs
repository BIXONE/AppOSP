using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekaOSP.Modele;

public class Kwota
{
    public decimal Wartość { get; set; }
    public Waluta Symbol { get; set; }

    public Kwota(Kwota kwota)
    {
        Wartość = kwota.Wartość;
        Symbol = kwota.Symbol;
    }

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

    public override string ToString()
    {
        return Wartość.ToString() + " " + Symbol.ToString();
    }

    public static Kwota operator +(Kwota a, Kwota b)
    {
        if (a.Symbol == b.Symbol)
        {
            return new Kwota((a.Wartość + b.Wartość), a.Symbol);
        }
        throw new Exception("Dwie różne waluty");
    }
}
