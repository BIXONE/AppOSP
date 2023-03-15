using BibliotekaOSP.Enumy;

namespace BibliotekaOSP.Modele;

public class ZmianyZarządu
{
    public int Id { get; set; }
    public FunkcjCzłonka Funkcja { get; set; }
    public int IdCzłonka { get; set; }
}
