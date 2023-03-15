namespace BibliotekaOSP.Modele;

public class Portfel
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    public Kwota StanKonta { get; }
}
