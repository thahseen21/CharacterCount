using Business.ViewModel;

namespace Business.IService
{
    public interface ICharacterCount
    {
        IList<CharacterCountVm> GetCharcterCount(string input);
        IEnumerable<CharacterCountVm> GetCharacterCountByLinq(string input);
    }
}
