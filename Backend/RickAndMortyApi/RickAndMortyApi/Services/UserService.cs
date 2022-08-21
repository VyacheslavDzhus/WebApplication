using RickAndMortyApi.DAL.Models;
using RickAndMortyApi.DAL.Repositories;
using RickAndMortyApi.Extensions;
using RickAndMortyApi.Models;
using RickAndMortyApi.Util;
using System;

namespace RickAndMortyApi.Services
{
    public class UserService : IUserService
    {
        private readonly IEntityRepository<User> userRepo;
        private readonly IAuthManager authManager;
        public UserService(IEntityRepository<User> userRepo, IAuthManager authManager)
        {
            this.userRepo = userRepo;
            this.authManager = authManager;
        }
        public async Task<UserDto> Create(UserDto dto)
        {
            authManager.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = dto.ToDomain();

            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            var createdUser = await userRepo.Create(newUser);

            return createdUser.ToModel();
        }

        public async Task<string> GetJwtToken(UserDto dto)
        {
            var users = await userRepo.GetAll();

            var user = users.ToList().Find(x => x.UserName == dto.Login);

            if (user is null)
            {
                throw new NullReferenceException();
            }

            if (!authManager.IsVerifiedPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException();
            }

            var jwtToken = authManager.CreateJwtToken(user);

            return jwtToken;
        }

        public async Task<UserDto> GetUser(UserDto dto)
        {
            var users = await userRepo.GetAll();

            var user = users.ToList().Find(x => x.UserName == dto.Login);

            if (user is null)
            {
                throw new NullReferenceException();
            }

            return user.ToModel();
        }
    }
}
