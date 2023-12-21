//using Core.Domain;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Microsoft.IdentityModel.Tokens;
//using RideLinkerAPI.Models;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace RideLinkerAPI.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AccountController : ControllerBase
//    {
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly SignInManager<IdentityUser> _signInManager;
//        private readonly IConfiguration _configuration;
//        private readonly ILogger<AccountController> _logger;

//        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, ILogger<AccountController> logger)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _configuration = configuration;
//            _logger = logger;
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginModel model)
//        {
//            _logger.LogInformation($"Login attempt for email: {model.Email}");

//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var result = await _signInManager.PasswordSignInAsync(
//                        model.Email,
//                        model.Password,
//                        false,
//                        false
//                    );

//                    if (result.Succeeded)
//                    {
//                        var id = _userManager.GetUserId(User);
//                        var user = await _userManager.FindByIdAsync(id);

//                        _logger.LogInformation($"????????????????????model.Email is: {model.Email} ");
//                        _logger.LogInformation($"!!!!!!!!!!!!!!!!!!!!User found: {user?.Email}");


//                        if (user != null)
//                        {
//                            var token = GenerateJwtToken(user);
//                            return Ok("Login succeeded: " + result.Succeeded + new { Token = token });
//                        }
//                        else
//                        {
//                            _logger.LogError("User is null after successful login.");
//                            return StatusCode(500, "Invalid login attempt, wrong email/password combination.");
//                        }
//                    }
//                    else
//                    {
//                        _logger.LogWarning($"Invalid login attempt.");
//                        return StatusCode(500,"Invalid login attempt.");
//                    }
//                }

//                _logger.LogWarning($"Invalid model state for login attempt for email: {model.Email}");
//                return BadRequest("Invalid model state.");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"An error occurred during login: {ex.Message}");
//                return StatusCode(500, "An internal server error occurred.");
//            }
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] RegisterModel model)
//        {
//            _logger.LogInformation($"Register attempt for email: {model.Email}");

//            if (ModelState.IsValid)
//            {
//                   var user = new User
//                   {
//                    UserName = model.Email,
//                    Email = model.Email
//                };

//                var result = await _userManager.CreateAsync(user, model.Password);

//                if(result.Succeeded)
//                {
//                    await _signInManager.SignInAsync(user, false);
//                    return Ok("Account registered.");
//                }

//                foreach(var error in result.Errors)
//                {
//                    ModelState.AddModelError(string.Empty, error.Description);
//                }
//                return BadRequest(ModelState);
//            }

//            return BadRequest("Invalid registration attempt.");
//        }

//        [HttpPost("logout")]
//        public async Task<IActionResult> Logout()
//        {
//            await _signInManager.SignOutAsync();
//            return Ok("Logout successful");
//        }

//        private string GenerateJwtToken(User user)
//        {
//            var claims = new List<Claim>
//        {
//            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//            new Claim(ClaimTypes.Name, user.Email)
//        };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                _configuration["JwtSettings:Issuer"],
//                _configuration["JwtSettings:Audience"],
//                claims,
//                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpirationInMinutes"])),
//                signingCredentials: creds
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }


//}
