namespace BibliotekaOSP.Interfejsy
{
    public interface ICzłonkowieService
    {
        void UtwórzCzłonka(UtwórzCzłonkaDto utwórzCzłonkaDto);
        bool EdytujCzłonka(int członekId, UtwórzCzłonkaDto utwórzCzłonkaDto);
        CzłonekDto? PobierzCzłonka(int członekId);
        List<CzłonekDto>? PobierzCzłonków();
    }
}