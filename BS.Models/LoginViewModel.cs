namespace BS.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        [DisplayName("Tên người dùng")]
        [Display(Name = "Tên người dùng")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [DisplayName("Ghi nhớ mật khẩu?")]
        [Display(Name = "Ghi nhớ mật khẩu?")]
        public bool RememberMe { get; set; }
    }
}
