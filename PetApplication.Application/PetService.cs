using System.Collections.Generic;
using System.Threading.Tasks;
using PetApplication.Domain;

namespace PetApplication.Application {
    public class PetService {
        private readonly IPetRepository _repository;

        public PetService(IPetRepository repository) {
            _repository = repository;
        }

        public Task<Pet> GetPet(int id) {
            return _repository.GetAsync(id);
        }

        public Task<IEnumerable<Pet>> GetAllPets() {
            return _repository.GetAllAsync();
        }

        public Task AddPet(Pet pet) {
            return _repository.AddAsync(pet);
        }

        public Task UpdatePet(Pet pet) {
            return _repository.UpdateAsync(pet);
        }

        public Task DeletePet(Pet pet) {
            return _repository.DeleteAsync(pet);
        }
    }
}
