using Api.Model;
using Business.IService;
using Business.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HomeController : ControllerBase
{
    public ICharacterCount CharacterCount { get; }

    public HomeController(ICharacterCount characterCount)
    {
        CharacterCount = characterCount;
    }

    [HttpPost(Name = "CharacterCount")]
    public IEnumerable<CharacterCountVm> GetCharacterCount([FromBody] GetCharactCountInputVm input)
    {
        return CharacterCount.GetCharacterCountByLinq(input.Input);
    }
}
