namespace BibliotekaOSP.ModeleDto;

public class CzłonekDto
{
    public int Id { get; set; }
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
    public bool czyJestAdresKorespondencji { get; set; }

    public AdresDto? AdresZamieszkania { get; set; }
    public AdresDto? AdresKorespondencji { get; set; }
}
