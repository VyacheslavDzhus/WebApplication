using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services;

namespace RickAndMortyApi.Controllers
{
    [Route("api/character")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService characterService;
        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;   
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllCharacters()
        {
            var characters = await characterService.GetAll();

            return Ok(characters);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            var character = await characterService.GetById(id);

            return Ok(character);
        }

        [HttpPut()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCharacter([FromBody] CharacterDto dto)
        {
            var updatedUser = await characterService.Update(dto);

            return Ok(updatedUser);
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCharacter([FromBody] CharacterDto dto)
        {
            var createdCharacter = await characterService.Create(dto);

            return Ok(createdCharacter);
        }

        [HttpDelete()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCharacter([FromBody] CharacterDto dto)
        {
            await characterService.Delete(dto);

            return Ok("Character was deleted");
        }
    }
}
