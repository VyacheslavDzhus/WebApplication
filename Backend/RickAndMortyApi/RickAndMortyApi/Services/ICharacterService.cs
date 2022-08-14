using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services
{
    public interface ICharacterService
    {
        Task<CharacterDto> Create(CharacterDto dto);
        Task<CharacterDto> Update(CharacterDto dto);
        Task Delete(CharacterDto dto);
        Task<CharacterDto> GetById(int characterId);
        Task<IEnumerable<CharacterDto>> GetAll();
    }
}
