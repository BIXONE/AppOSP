using BibliotekaOSP.Enumy;

namespace BibliotekaOSP.ModeleDto;

public class UtwórzCzłonkaDto
{
    public string Imię { get; set; }
    public string Nazwisko { get; set; }
    public Płeć Płeć { get; set; }
    public StatusCzłonka StatusCzłonka { get; set; }
    public DateTime? DataUrodzenia { get; set; }
    public DateTime? DataSzkolenia { get; set; }
    public DateTime? DataWażnościBadania { get; set; }
    public DateTime? DataWstąpieniaDoOSP { get; set; }
    public DateTime? DataWystąpieniaZOSP { get; set; }
    public int? NumerTelefonu { get; set; }
    public string? UlicaMiasto { get; set; }
    public string? Numer { get; set; }
    public string? KodPocztowy { get; set; }
    public string? Miejscowość { get; set; }
    public bool czyJestAdresKorespondencji { get; set; }
    public string? UlicaMiastoKorespondencji { get; set; }
    public string? NumerKorespondencji { get; set; }
    public string? KodPocztowyKorespondencji { get; set; }
    public string? MiejscowośćKorespondencji { get; set; }
}
