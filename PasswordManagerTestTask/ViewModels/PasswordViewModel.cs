using System.ComponentModel.DataAnnotations;

namespace PasswordManagerTestTask.ViewModels
{
    public class PasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SiteName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(int.MaxValue, MinimumLength = 8, ErrorMessage = "Пароль должен содержать минимум {2} символов")]
        public string Password { get; set; }
    }
}
