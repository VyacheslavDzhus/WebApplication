using RickAndMortyApi.DAL.Models;

namespace RickAndMortyApi.Models
{
    public class LoginDto
    {
        public LoginDto(User user, string token)
        {
            if(user is not null)
            {
                Name = user.Name;
                LastName = user.LastName;
            }

            if (!string.IsNullOrWhiteSpace(token))
            {
                Token = token;
            }
        }
        public string Name { get; }
        public string LastName { get; }
        public string Token { get; }
    }
}
