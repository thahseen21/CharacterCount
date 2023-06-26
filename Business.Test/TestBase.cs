using Business.IService;
using Business.Service;

namespace Business.Test
{
    public class TestBase
    {
        public ICharacterCount characterCount { get; set; }

        public TestBase()
        {
            characterCount = new CharacterCount();
        }
    }
}