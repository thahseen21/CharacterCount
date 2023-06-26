using Business.IService;
using Business.ViewModel;

namespace Business.Service
{
    public class CharacterCount : ICharacterCount
    {
        public IList<CharacterCountVm> GetCharcterCount(string input)
        {
            var result = new List<CharacterCountVm>();

            foreach (var i in input)
            {
                if (result.Count <= 0)
                {
                    if (i != ' ')
                    {
                        result.Add(new CharacterCountVm() { Key = i, Count = 1 });
                    }
                }
                else
                {
                    CharacterCountVm? found = null;

                    foreach (CharacterCountVm r in result.ToList())
                    {
                        if (r.Key == i)
                        {
                            found = r;
                        }
                    }

                    if (found != null)
                    {
                        found.Count++;
                    }
                    else
                    {
                        if (i != ' ')
                        {
                            result.Add(new CharacterCountVm() { Key = i, Count = 1 });
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<CharacterCountVm> GetCharacterCountByLinq(string input)
        {
            List<string> chars = new();
            chars.AddRange(input.Select(c => c.ToString()));

            var result = chars
                .Where(x => x != " ")
                .GroupBy(x => x)
                .Select(g => new CharacterCountVm { Key = g.First()[0], Count = g.Count() })
                .ToList();

            return result;
        }
    }
}
