using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        // we use a Data Transfer Object since
        //   1) it is more stable (less frequent changes) than the underlying class on which it's based
        //   2) it is more secure to only expose the properties that SHOULD be editable, rather than ALL properties of the underlying class

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")] // this annotation says that the Name property is required and specifies custom validation text
        [StringLength(255)] // this annotation says that the Name property has a max char length of 255
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; } // all struct types are required by default unless you mark them as nullable. see below

        // don't couple DTOs to domain objects! if the DTO needs to talk to an object, create a DTO for that object!
        public MembershipTypeDto MembershipType { get; set; }

        // commented out since it would throw an exception due to the hard reference to the Customer class
        //[Min18YearsIfAMember] // a custom validation class!
        public DateTime? Birthdate { get; set; } // this property is nullable because of the '?'
    }
}