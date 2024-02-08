using System.ComponentModel.DataAnnotations;

namespace OkyanusWebAPI.Models.Identitiy
{
    public class LoginUserVM
    {
        [Required(ErrorMessage = "Kullanıcı adı veya Mail Giriniz")]
        public string UsernameOrEmail { get; set; }
        [Required(ErrorMessage = "Şifre Giriniz")]
        public string Password { get; set; }
    }
}
