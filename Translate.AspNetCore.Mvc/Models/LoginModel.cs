using System.ComponentModel.DataAnnotations;

namespace Translate.AspNetCore.Mvc.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "E-POSTA ALANI ZORUNLU")]
        public string Email { get; set; }

        [Required(ErrorMessage = "ŞİFRE ALANI ZORUNLU")]
        public string Password { get; set; }
    }
}
