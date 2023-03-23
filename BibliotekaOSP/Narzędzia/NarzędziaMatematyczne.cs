namespace BibliotekaOSP.Narzędzia;

public static class NarzędziaMatematyczne
{
    public static decimal ZaokrąglijCena(decimal wartość)
    {
        return Math.Round(wartość, 2);
    }

    public static Kwota? SumaKwot(Kwota kwota1, Kwota kwota2)
    {
        if (kwota1.Symbol == kwota2.Symbol)
        {
            kwota1.Wartość += kwota2.Wartość;
            return kwota1;
        }
        return null;
    }
}
