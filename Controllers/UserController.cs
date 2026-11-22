
using IEQ2_BSIT32A1_Rollano.DTO.DATA;
using IEQ2_BSIT32A1_Rollano.DTO.User;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IEQ2_BSIT32A1_Rollano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        // Get all users
        [HttpGet]
        public IActionResult Get()
        {
            var response = new GetUserResponse();

            response.Users = StaticUser.Users.Select(user => new GetUserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }).ToList();

            return Ok(response);
        }

        // GET: api/User/1
        // Get user by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = StaticUser.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound("User not found.");

            var response = new GetUserResponse();

            response.Users.Add(new GetUserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            });

            return Ok(response);
        }

        // POST: api/User
        // Create new user
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserRequest value)
        {
            var newUser = new User
            {
                Id = StaticUser.Users.Any()
                    ? StaticUser.Users.Max(x => x.Id) + 1
                    : 1,
                Name = value.Name,
                Email = value.Email
            };

            StaticUser.Users.Add(newUser);

            return CreatedAtAction(
                nameof(GetById),
                new { id = newUser.Id },
                newUser
            );
        }

        // PUT: api/User/1
        // Update existing user
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditUserRequest value)
        {
            var user = StaticUser.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound("User not found.");

            user.Name = value.Name;
            user.Email = value.Email;

            return Ok(user);
        }

        // DELETE: api/User/1
        // Delete user
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = StaticUser.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound("User not found.");

            StaticUser.Users.Remove(user);

            return NoContent();
        }
    }
}
