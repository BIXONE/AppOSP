namespace BibliotekaOSP.Modele;

public abstract class Przelew
{
    public int Id { get; set; }
    public DateTime DataZlecenia { get; set; }
    public int IdPortfel { get; set; }
    public Kwota Kwota { get; set; }
}
