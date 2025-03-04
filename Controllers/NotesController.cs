using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesServer.Context;
using NotesServer.Models;

namespace NotesServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DbContext _context;
        public NotesController(DbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserNotes(string userId)
        {
            var query = "select * from Notes where UserId=@UserId";
            using var connection = _context.CreateConnection();
            var notes = await connection.QueryAsync<Note>(query, new { UserId = userId });

            if (notes == null)
            {
                return Ok(new { message = "No notes found" });
            }

            return Ok(notes);
        }
    }
}
