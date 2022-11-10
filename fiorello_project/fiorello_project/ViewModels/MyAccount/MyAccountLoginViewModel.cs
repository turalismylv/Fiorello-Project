using System.ComponentModel.DataAnnotations;

namespace fiorello_project.ViewModels.MyAccount
{
    public class MyAccountLoginViewModel
    {
        [Required, MaxLength(100), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(100), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
