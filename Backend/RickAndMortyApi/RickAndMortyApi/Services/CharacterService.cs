using RickAndMortyApi.DAL.Models;
using RickAndMortyApi.DAL.Repositories;
using RickAndMortyApi.Extensions;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IEntityRepository<Character> characterRepo;

        public CharacterService(IEntityRepository<Character> characterRepo)
        {
            this.characterRepo = characterRepo;
        }
        public async Task<CharacterDto> Create(CharacterDto dto)
        {
            var createdCharacter = await characterRepo.Create(dto.ToDomain());

            return createdCharacter.ToModel();
        }

        public async Task Delete(CharacterDto dto)
        {
            await characterRepo.Delete(dto.ToDomain()).ConfigureAwait(false);
        }

        public async Task<IEnumerable<CharacterDto>> GetAll()
        {
            var characters = await characterRepo.GetAll();

            return characters.Select(character => character.ToModel()).ToList();
        }

        public async Task<CharacterDto> GetById(int characterId)
        {
            var character = await characterRepo.GetById(characterId);

            return character.ToModel();
        }

        public async Task<CharacterDto> Update(CharacterDto dto)
        {
            var updatedCharacter = await characterRepo.Update(dto.ToDomain());

            return updatedCharacter.ToModel();
        }
    }
}
