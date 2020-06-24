using GiftSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GiftSystem.Data
{
    public class GiftSystemDbContext : IdentityDbContext<GiftSystemUser, IdentityRole, string>
    {
        public GiftSystemDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
