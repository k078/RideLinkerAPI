using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DomainService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RL
{
    public class CarRepository : ICarRepository
    {
        private readonly RideLinkerDbContext _context;

        public CarRepository(RideLinkerDbContext context)
        {
            _context = context;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task AddAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Car car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
