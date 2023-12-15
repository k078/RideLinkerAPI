using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RideLinkerAPI.Services;
using Models; 

namespace RideLinkerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase 
    {
        private readonly ILogger<CarController> _logger;
        private readonly CarService _carService;

        public CarController(ILogger<CarController> logger, CarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            _logger.LogInformation("GetAllCars() aangeroepen");
            var cars = _carService.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            _logger.LogInformation($"GetCarById({id}) aangeroepen");
            var car = _carService.GetCarById(id);

            if (car == null)
            {
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

            _carService.AddCar(newCar);

            return CreatedAtAction(nameof(GetCarById), new { id = newCar.id }, newCar);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] Car updatedCar)
        {
            _logger.LogInformation($"UpdateCar({id}) aangeroepen");

            if (updatedCar == null)
            {
                return BadRequest();
            }

            _carService.UpdateCar(id, updatedCar);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            _logger.LogInformation($"DeleteCar({id}) aangeroepen");

            _carService.DeleteCar(id);

            return NoContent();
        }
    }
}
