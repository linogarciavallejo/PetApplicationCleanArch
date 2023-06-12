using Microsoft.AspNetCore.Mvc;
using PetApplication.Application;
using PetApplication.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetService _petService;

        public PetController(PetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public Task<IEnumerable<Pet>> Get()
        {
            return _petService.GetAllPets();
        }

        [HttpGet("{id}")]
        public Task<Pet> Get(int id)
        {
            return _petService.GetPet(id);
        }

        [HttpPost]
        public Task Post([FromBody] Pet pet)
        {
            return _petService.AddPet(pet);
        }

        [HttpPut("{id}")]
        public Task Put(int id, [FromBody] Pet pet)
        {
            return _petService.UpdatePet(pet);
        }

        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _petService.DeletePet(new Pet { Id = id });
        }
    }
}
