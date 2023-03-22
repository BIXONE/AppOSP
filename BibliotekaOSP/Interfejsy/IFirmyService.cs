namespace BibliotekaOSP.Interfejsy
{
    public interface IFirmyService
    {
        void UtwórzFirmę(UtwórzFirmęDto utwórzFirmęDto);
        bool EdytujFirmę(int firmaId, UtwórzFirmęDto utwórzFirmęDto);
        FirmaDto? PobierzFirmę(int firmaId);
        List<FirmaDto>? PobierzFirmy();
    }
}