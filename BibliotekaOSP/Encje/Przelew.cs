namespace BibliotekaOSP.Encje;

public class Przelew
{
    public int Id { get; set; }
    public DateTime DataZlecenia { get; set; }
    public Kwota Kwota { get; set; }
    public string Tytuł { get; set; }
    public string Komentarz { get; set; } = string.Empty;
    public int? ZleceniodawcaId { get; set; }
    public int? FirmyId { get; set; }
    public bool Blokada { get; set; }

    public int PortfelId { get; set; }
    public virtual Portfel Portfel { get; set; }
}
