using Microsoft.AspNetCore.Identity;

namespace GiftSystem.Models
{
    public class GiftSystemUser : IdentityUser
    {
        public GiftSystemUser()
        {
            this.Credits = 100;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Credits { get; set; }
    }
}


