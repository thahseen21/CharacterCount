using Business.ViewModel;

namespace Business.IService
{
    public interface ICharacterCount
    {
        List<CharacterCountVm> GetCharcterCount(string input);
        List<CharacterCountVm> GetCharacterCountByLinq(string input);
    }
}
