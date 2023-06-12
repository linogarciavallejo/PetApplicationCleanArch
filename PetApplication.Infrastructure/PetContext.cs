using Microsoft.EntityFrameworkCore;
using PetApplication.Domain;

namespace PetApplication.Infrastructure {
    public class PetContext : DbContext {
        public PetContext(DbContextOptions<PetContext> options) : base(options) {
        }

        public DbSet<Pet> Pets { get; set; }
    }
}
