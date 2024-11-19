using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RotasParaOFuturo.Models;

namespace RotasParaOFuturo.Data
{
    public class IdentityContext: IdentityDbContext<Admin>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options): base(options) 
        {
            
        }
    }
}
