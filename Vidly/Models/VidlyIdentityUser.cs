using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class VidlyIdentityUser : IdentityUser
    {

        [Required]
        [StringLength(255)]
        public string DrivingLicense { get; set; } = default!;

    }
}
