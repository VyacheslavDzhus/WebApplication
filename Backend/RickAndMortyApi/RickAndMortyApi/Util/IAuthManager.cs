using RickAndMortyApi.DAL.Models;

namespace RickAndMortyApi.Util
{
    public interface IAuthManager
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool IsVerifiedPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateJwtToken(User user);
    }
}
