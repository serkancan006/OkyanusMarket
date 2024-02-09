using System.ComponentModel.DataAnnotations;

namespace OkyanusWebUI.Models.LoginVM
{
    public class LoginUserVM
    {
        [Required(ErrorMessage = "Kullanıcı adınızı yada Emailinizi giriniz")]
        public string UserNameOrEmail { get; set; }
        [Required(ErrorMessage = "Şifre giriniz")]
        public string Password { get; set; }
    }
}
