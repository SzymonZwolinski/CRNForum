using System.ComponentModel.DataAnnotations;

namespace Platender.Front.Models
{
    public class UserPasswordChange
    {
        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.")]
        public string NewPassword { get; set; }

        [Required]
        [Compare(nameof(NewPassword))]
        public string NewPassword2 { get; set; }
    }
}
