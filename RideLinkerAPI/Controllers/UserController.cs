using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Domain;
using Core.DomainService.Interfaces;

namespace RideLinkerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<CarController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogInformation("GetAllUsers() aangeroepen");

            try
            {
                var users = await _userService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fout bij het ophalen van users: {ex.Message}");
                return StatusCode(500, "Er is een interne fout opgetreden bij het ophalen van users.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            _logger.LogInformation($"GetUserById({id}) aangeroepen");
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                _logger.LogError($"User met id {id} niet gevonden");
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost()]
        public async Task<IActionResult> AddUser([FromBody] User inUser)
        {
            _logger.LogInformation("AddUser() aangeroepen");

            try
            {
                await _userService.AddAsync(inUser);
                return Ok(inUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fout bij het toevoegen van een user: {ex.Message}");
                return StatusCode(500, "Er is een interne fout opgetreden bij het toevoegen van een user.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            _logger.LogInformation($"UpdateUser({id}) aangeroepen");

            if (updatedUser == null)
            {
                return BadRequest();
            }

            updatedUser.Id = id;

            try
            {
                await _userService.UpdateAsync(updatedUser);

                if (updatedUser == null)
                {
                    return NotFound();
                }

                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fout bij het bijwerken van user: {ex.Message}");
                return StatusCode(500, "Er is een interne fout opgetreden bij het bijwerken van een user.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _logger.LogInformation($"DeleteUser({id}) aangeroepen");

            try
            {
                await _userService.DeleteAsync(id);
                return Ok("User ID gedelete: " + id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fout bij het verwijderen van de user: {ex.Message}");
                return StatusCode(500, "Er is een interne fout opgetreden bij het verwijderen van de user.");
            }
        }
    }
}
