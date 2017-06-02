using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required] // this annotation says that the Name property is no longer nullable
        [StringLength(255)] // this annotation says that the Name property has a max char length of 255
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        // by convention, entity framework treats this naming syntax
        //   as a db foreign key to the primary key (Id) of MembershipType
        public byte MembershipTypeId { get; set; }
    }
}