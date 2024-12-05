using Employee.Management.Api.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // Check if the user already exists
            var userExist = await _userManager.FindByEmailAsync(model.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new Response
                {
                    IsSuccess = false,
                    Message = "User already exists."
                });
            }

            // Create a new user
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            // Check if the creation was successful
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    IsSuccess = false,
                    Message = "User creation failed. Please check details.",
                    ErrorDetails = string.Join(", ", result.Errors.Select(e => e.Description))
                });
            }

            // Return success response
            return Ok(new Response
            {
                IsSuccess = true,
                Message = "User registered successfully."
            });
        }


    }
}
