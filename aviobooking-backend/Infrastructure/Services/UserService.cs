using Application.Abstractions.Authentication;
using Application.Abstractions.Services;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User?> GetByIdAsync(StronglyTypedId<User> id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            return await _userRepository.ExistsByEmail(email);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task CreateAsync(User user)
        {
            user.Password = _passwordHasher.Hash(user.Password); // Hashing password before saving
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(StronglyTypedId<User> id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return false;

            return _passwordHasher.Verify(password, user.Password);
        }
    }

}
