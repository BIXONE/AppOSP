using BibliotekaOSP.Encje;

namespace BibliotekaOSP.ModeleDto;

public class UtwórzFirmęDto
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public ulong? REGON { get; set; }
    public ulong? NIP { get; set; }
    public ulong? KRS { get; set; }
    public int? AdresSiedzibyId { get; set; }
    public int? AdresKorespondencjiId { get; set; }
    public int? NumerTelefonu { get; set; }
    public string? UlicaMiasto { get; set; }
    public string? Numer { get; set; }
    public string? KodPocztowy { get; set; }
    public string? Miejscowość { get; set; }
    public bool InnyAdresKorespondencji { get; set; }
    public string? UlicaMiastoKorespondencji { get; set; }
    public string? NumerKorespondencji { get; set; }
    public string? KodPocztowyKorespondencji { get; set; }
    public string? MiejscowośćKorespondencji { get; set; }
}
