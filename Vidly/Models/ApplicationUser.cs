using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class ApplicationUser : IdentityUser
    {
        // added a new required field to the applicationuser for use in our login view.
        // this required a db migration.
        [Required]
        [StringLength(255)]
        public string DriverLicense { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}