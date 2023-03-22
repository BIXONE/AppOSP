using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekaOSP.Encje;

public class Firma
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public ulong? REGON { get; set; }
    public ulong? NIP { get; set; }
    public ulong? KRS { get; set; }
    public int? NumerTelefonu { get; set; }
    public bool czyJestAdresKorespondencji { get; set; }
    public int AdresSiedzibyId { get; set; }
    public int AdresKorespondencjiId { get; set; }

    [NotMapped]
    public virtual Adres AdresSiedziby { get; set; }
    [NotMapped]
    public virtual Adres AdresKorespondencji { get; set; }
}
