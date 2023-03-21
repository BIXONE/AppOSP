namespace BibliotekaOSP.ModeleDto;

public class FirmaDto
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public ulong? REGON { get; set; }
    public ulong? NIP { get; set; }
    public ulong? KRS { get; set; }
    public int? NumerTelefonu { get; set; }
    public AdresDto AdresSiedziby { get; set; }
    public AdresDto AdresKorespondencji { get; set; }
}
