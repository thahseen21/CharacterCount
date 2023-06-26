using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class GetCharactCountInputVm
    {
        [Required(ErrorMessage = "Input is required")]
        public string Input { get; set; }
    }
}
