using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetApplication.Domain {
    public interface IPetRepository {
        Task<Pet> GetAsync(int id);
        Task<IEnumerable<Pet>> GetAllAsync();
        Task AddAsync(Pet pet);
        Task UpdateAsync(Pet pet);
        Task DeleteAsync(Pet pet);
    }
}
