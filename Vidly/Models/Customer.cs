using System.ComponentModel.DataAnnotations;
using Vidly.Models.Validation;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = default!;

        [Display(Name = "Date of birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership type")]
        [Required(ErrorMessage = "Membership type is required")]
        public byte? MembershipTypeId { get; set; }

        public MembershipType? MembershipType { get; set; }

    }
}
