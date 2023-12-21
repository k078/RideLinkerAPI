using Core.Domain;
using Core.DomainService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RideLinkerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            _logger.LogInformation("GetAllReservations called");

            try
            {
                var reservations = await _reservationService.GetAllAsync();
                return Ok(reservations);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrieving reservations: {ex.Message}");
                return StatusCode(500, "An internal error occurred while retrieving reservations.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            _logger.LogInformation($"GetReservationById({id}) called");

            try
            {
                var reservation = await _reservationService.GetByIdAsync(id);
                if (reservation == null)
                {
                    return NotFound();
                }
                return Ok(reservation);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrieving reservation with id {id}: {ex.Message}");
                return StatusCode(500, "An internal error occurred while retrieving the reservation.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] Reservation reservation)
        {
            _logger.LogInformation("AddReservation called");

            try
            {
                if (reservation == null)
                {
                    return BadRequest("Reservation data is null");
                }
                await _reservationService.AddAsync(reservation);
                return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Id }, new { message = "Reservation created successfully", reservation });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while adding a reservation: {ex.Message}");
                return StatusCode(500, "An internal error occurred while adding the reservation.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] Reservation reservation)
        {
            _logger.LogInformation($"UpdateReservation({id}) called");

            try
            {
                if (reservation == null)
                {
                    return BadRequest("Reservation data is invalid");
                }

                var existingReservation = await _reservationService.GetByIdAsync(id);
                if (existingReservation == null)
                {
                    return NotFound($"Reservation with ID {id} not found.");
                }

                reservation.Id = id;
                await _reservationService.UpdateAsync(reservation);
                return Ok(new { message = "Reservation updated successfully", reservation });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while updating reservation with id {id}: {ex.Message}");
                return StatusCode(500, "An internal error occurred while updating the reservation.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            _logger.LogInformation($"DeleteReservation({id}) called");

            try
            {
                var reservation = await _reservationService.GetByIdAsync(id);
                if (reservation == null)
                {
                    return NotFound();
                }

                await _reservationService.DeleteAsync(id);
                return Ok(new { message = "Reservation deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while deleting reservation with id {id}: {ex.Message}");
                return StatusCode(500, "An internal error occurred while deleting the reservation.");
            }
        }
    }
}
