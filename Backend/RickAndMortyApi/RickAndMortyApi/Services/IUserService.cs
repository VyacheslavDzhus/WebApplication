using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services
{
    public interface IUserService
    {
        Task<UserDto> Create(UserDto dto);
        Task<string> GetJwtToken(UserDto dto);
        Task<UserDto> GetUser(UserDto dto);
    }
}
