namespace BibliotekaOSP.Modele;

public class Firma
{
    public string Nazwa { get; set; }
    public Adres AdresSiedziby { get; set; }
    public Adres? AdresKorespondencji { get; set; } /// Jeśli brak to adres siedziby
}
