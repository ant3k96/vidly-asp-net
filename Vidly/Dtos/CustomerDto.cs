using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = default!;

        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required(ErrorMessage = "Membership type is required")]
        public byte? MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; } = default!;
    }
}
