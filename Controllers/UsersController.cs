using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesServer.Context;
using NotesServer.Models;

namespace NotesServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DbContext _context;
        public UsersController(DbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var qurey = "select * from Users where UserId=@UserId";
            using var connection = _context.CreateConnection();
            var user = await connection.QueryFirstOrDefaultAsync<User>(qurey, new { UserId = userId });
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }
            else
            {
                return Ok(user);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var query = "Insert into Users values (@UserId,@UserName,@UserEmail)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, user);
            return Created("", user);
        }
    }
}
