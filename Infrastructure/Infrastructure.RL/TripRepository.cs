using Core.Domain;
using Core.DomainService.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TripRepository> _logger;

        public TripRepository(RideLinkerDbContext context, ILogger<TripRepository> logger)
        {
            _context = context;
            _logger = logger;   
        }

        public async Task<Trip> GetByIdAsync(int id)
        {
            return await _context.Trips
                .Include(t => t.Car)
                .ThenInclude(c => c.Location)
                .Include(t => t.Driver)
                .Include(t => t.Departure)
                .Include(t => t.Destination)
                .FirstAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Trip>> GetAllAsync()
        {
            return await _context.Trips
                .Include(t => t.Car)
                .ThenInclude(c => c.Location)
                .Include(t => t.Driver)
                .Include(t => t.Departure)
                .Include(t => t.Destination)
                .ToListAsync();
        }

        public async Task AddAsync(Trip trip)
        {
            await _context.Trips.AddAsync(trip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trip trip)
        {
            var tripToUpdate = await _context.Trips.FindAsync(trip.Id);

            _logger.LogInformation("Updating car with id: " + trip.Id);

            if (tripToUpdate != null)
            {
                _context.Entry(tripToUpdate).CurrentValues.SetValues(trip);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            _context.Trips.Remove(await _context.Trips.FindAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}
