﻿using Core.Domain;
using Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RL
{
    public class UserRepository : IUserRepository
    {
        private readonly YourDbContext _context;

        public UserRepository(YourDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
