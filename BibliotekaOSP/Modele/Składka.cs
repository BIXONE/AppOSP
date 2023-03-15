namespace BibliotekaOSP.Modele;

public class Składka
{
    public int Id { get; set; }
    public int IdCzłonka { get; set; }
    public DateTime DataWpłaty { get; set; }
    public Kwota Kwota { get; set; }
}
