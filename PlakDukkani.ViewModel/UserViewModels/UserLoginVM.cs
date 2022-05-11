
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani.ViewModel.UserViewModels
{
    public class UserLoginVM
    {

        [Display(Name = "Email Address", Prompt = "e-mail address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} exception")]
        [StringLength(100, ErrorMessage = "max 100 character", MinimumLength = 10)]
        [Required(ErrorMessage = "{0} is Required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "password")]
        [StringLength(20, ErrorMessage = "max 100 character", MinimumLength = 5)]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
