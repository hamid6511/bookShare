using bookShare.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookShare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersServices usersService;
        public UsersController( UsersServices usersServices)
        {
            usersService = usersServices;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = usersService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("Get-user-id/{userId}")]
        public IActionResult GetUsers(Guid userId)
        {
            var user = usersService.GetUserById(userId);
            return Ok(user);
        }
        [HttpDelete("Delete-user-by-Id/{Id}")]
        public IActionResult DeleteById(Guid Id)
        {
           usersService.DeleteUserById(Id);
            return Ok();
        }

    }
}
