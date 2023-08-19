
using System.ComponentModel.DataAnnotations;

namespace persistence.Identity.IdentityModels
{
    public class LoginUser
    {
        [Required]
        public string UserName { get; set; }
      
        [Required]
        public string Password { get; set; }
    }
}
