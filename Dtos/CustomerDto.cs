using System;
using System.ComponentModel.DataAnnotations;
using vidly.Validator;

namespace vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        // [Min18Years]
        public DateTime? Birthdate { get; set; }
    }
}