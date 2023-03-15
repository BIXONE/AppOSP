namespace BibliotekaOSP.Modele;

public class Inwentarz
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public Kwota? Wartość { get; set; }
    public string Opis { get; set; }

    public Inwentarz(string nazwa, Kwota wartość, string opis = "")
    {
        Nazwa = nazwa;
        Wartość = wartość;
        Opis = opis;
    }
}
