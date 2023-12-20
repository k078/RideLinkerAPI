using Core.Domain;
using Core.DomainService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task AddAsync(User user)
        {
            return _repo.AddAsync(user);
        }

        public Task DeleteAsync(int id)
        {
            return _repo.DeleteAsync(id);
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<User> GetByIdAsync(int id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task UpdateAsync(User user)
        {
            return _repo.UpdateAsync(user);
        }
    }
}
