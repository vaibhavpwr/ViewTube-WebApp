using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AuthenticationService.Models
{
    public class User
    {
        [Key]

        public string UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
