using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;
using ToDoListAPI.ResponseDto;
using ToDoListAPI.Services;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [EnableCors]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserResponse>> GetUser(int id)
        {
            var result = await _userService.GetUser(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        //https://localhost:44348/api/User/2
        [HttpPost]
        public async Task<ActionResult<List<User?>>> AddUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var createdUser = await _userService.AddUser(user);

            return CreatedAtAction(nameof(GetUser),
                new { Id = createdUser?.UserId }, createdUser);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User?>> UpdateUser(int id, User request)
        {
            if (id != request.UserId)
            {
                return BadRequest("User Id mismatch");
            }

            var userToUpdateId = await _userService.GetUser(request.UserId);

            if (userToUpdateId == null)
            {
                return NotFound($"User with Id = {request.UserId} not found");
            }

            return await _userService.UpdateUser(request);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User?>> Delete(int id)
        {
            var userToDelete = await _userService.GetUser(id);

            if (userToDelete == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            return await _userService.DeleteUser(id);
        }

    }
}
