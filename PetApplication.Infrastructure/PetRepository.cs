using Microsoft.EntityFrameworkCore;
using PetApplication.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetApplication.Infrastructure {
    public class PetRepository : IPetRepository {
        private readonly PetContext _context;

        public PetRepository(PetContext context) {
            _context = context;
        }

        public async Task<Pet> GetAsync(int id) {
            return await _context.Pets.FindAsync(id);
        }

        public async Task<IEnumerable<Pet>> GetAllAsync() {
            return await _context.Pets.ToListAsync();
        }

        public async Task AddAsync(Pet pet) {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pet pet) {
            _context.Entry(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pet pet) {
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }
    }
}
