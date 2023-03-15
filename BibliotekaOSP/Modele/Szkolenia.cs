using BibliotekaOSP.Enumy;

namespace BibliotekaOSP.Modele;

public class SzkolenieUkończone
{
    public int Id { get; set; }
    public int IdCzłonka { get; set; }
    public DateTime DataSzkolenia { get; set; }
    public Szkolenie Szkolenie { get; set; }
}
