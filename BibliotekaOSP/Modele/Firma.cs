namespace BibliotekaOSP.Modele;

public class Firma
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public Adres AdresSiedziby { get; set; }
    public Adres? AdresKorespondencji { get; set; } /// Jeśli brak to adres siedziby
    public ulong REGON { get; set; }
    public ulong NIP { get; set; }
    public ulong KRS { get; set; }
}
