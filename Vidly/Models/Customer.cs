using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required.")] // this annotation says that the Name property is required and specifies custom validation text
        [StringLength(255)] // this annotation says that the Name property has a max char length of 255
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")] //one way to change the label name
        // by convention, entity framework treats this naming syntax
        //   as a db foreign key to the primary key (Id) of MembershipType
        public byte MembershipTypeId { get; set; } // all struct types are required by default unless you mark them as nullable. see below

        [Display(Name="Date of Birth")]
        [Min18YearsIfAMember] // a custom validation class!
        public DateTime? Birthdate { get; set; } // this property is nullable because of the '?'
    }
}