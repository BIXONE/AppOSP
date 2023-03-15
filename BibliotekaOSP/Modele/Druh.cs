using BibliotekaOSP.Enumy;

namespace BibliotekaOSP.Modele;

public class Druh
{
    public int Id { get; set; }
    public string Imię { get; set; }
    public string Nazwisko { get; set; }
    public Płeć Płeć { get; set; }
    public StatusDruha StatusDruha { get; set; }
    public Adres AdresZamieszkania { get; set; }
    public Adres? AdresKorespondencji { get; set; }
    public DateTime DataUrodzenia { get; set; }
    public DateTime DataSzkolenia { get; set; }
    public DateTime DataWażnościBadania { get; set; }
    public DateTime DataWstąpieniaDoOSP { get; set; }
    public DateTime DataWystąpieniaZOSP { get; set; }

}
