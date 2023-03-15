namespace BibliotekaOSP.Narzędzia;

public static class NarzędziaMatematyczne
{
    public static decimal ZaokrąglijCena(decimal wartość)
    {
        return Math.Round(wartość, 2);
    }
}
