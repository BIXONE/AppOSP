namespace BibliotekaOSP.Interfejsy;

public interface IPrzelewService
{
    void UtwórzPrzelew(UtwórzPrzelewDto utwórzPrzelewDto);
    bool? EdytujPrzelew(int przelewId, UtwórzPrzelewDto utwórzPrzelewDto);
    bool? UsuńPrzelew(int przelewId);
    PrzelewDto? PobierzPrzelew(int przelewId);
    List<PrzelewDto> PobierzWszystkiePrzelewyWgPortfela(int portfelId);
    List<PrzelewDto> PobierzPrzelewyPoDacieWgPrzelewu(DateTime odKiedy, DateTime doKiedy, int portfelId);
}