namespace BibliotekaOSP.Encje;

public class Portfel
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    public bool Blokada { get; set; }

    public virtual List<Przelew> Przelewy { get; set; }
}
