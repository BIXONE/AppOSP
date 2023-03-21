using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekaOSP.Encje;

public class Członek
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
    public int AdresZamieszkaniaId { get; set; }
    public int AdresKorespondencjiId { get; set; }

    [NotMapped]
    public virtual Adres AdresZamieszkania { get; set; }
    [NotMapped]
    public virtual Adres AdresKorespondencji { get; set; }
}
