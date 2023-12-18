using Core.Domain;
using Core.DomainService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RL
{
    public class TripRepository : ITripRepository
    {
        private readonly RideLinkerDbContext _context;

        public TripRepository(RideLinkerDbContext context)
        {
            _context = context;
        }

        public async Task<Trip> GetByIdAsync(int id)
        {
            return await _context.Trips.FindAsync(id);
        }

        public async Task<IEnumerable<Trip>> GetAllAsync()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task AddAsync(Trip trip)
        {
            await _context.Trips.AddAsync(trip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Trip trip)
        {
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
        }
    }
}
