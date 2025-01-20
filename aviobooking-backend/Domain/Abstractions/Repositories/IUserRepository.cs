using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(StronglyTypedId<User> id);
        Task<User?> GetByEmailAsync(string email);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(StronglyTypedId<User> id);
        Task<bool> ExistsByEmail(string email);
    }
}
