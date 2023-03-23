namespace BibliotekaOSP.Interfejsy;

public interface IPortfelService
{
    void UtwórzPortfel(UtwórzPortfelDto utwórzPortfelDto);
    bool? EdytujPortfel(int portfelId, UtwórzPortfelDto utwórzPortfelDto);
    bool? UsuńPortfel(int portfelId);
    Kwota WartośćPortfela(int portfelId);
}