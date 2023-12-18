using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Domain;
using Core.DomainService.Interfaces;

namespace RideLinkerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase 
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;

        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            _logger.LogInformation("GetAllCars() aangeroepen");

            try
            {
                var cars = await _carService.GetAllAsync();
                return Ok(cars);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fout bij het ophalen van auto's: {ex.Message}");
                return StatusCode(500, "Er is een interne fout opgetreden bij het ophalen van auto's.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            _logger.LogInformation($"GetCarById({id}) aangeroepen");
            var car = await _carService.GetByIdAsync(id);

            if (car == null)
            {
                _logger.LogError($"Auto met id {id} niet gevonden");
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] Car newCar)
        {
            _logger.LogInformation("AddCar() aangeroepen");

            if (newCar == null)
            {
                return BadRequest();
            }

             _carService.AddAsync(newCar);

            return Ok(newCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car updatedCar)
        {
            _logger.LogInformation($"UpdateCar({id}) aangeroepen");

            if (updatedCar == null)
            {
                return BadRequest();
            }

            updatedCar.Id = id;

            await _carService.UpdateAsync(updatedCar);

            return Ok("Geupdate auto: " + updatedCar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            _logger.LogInformation($"DeleteCar({id}) aangeroepen");

            try
            {
                await _carService.DeleteAsync(id);
                return Ok("Auto ID gedelete: " + id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fout bij het verwijderen van de auto: {ex.Message}");
                return StatusCode(500, "Er is een interne fout opgetreden bij het verwijderen van de auto.");
            }
        }
    }
}
