using Microsoft.AspNetCore.Mvc;
using Sqorm.WebApi.Models.Dto;
using Sqorm.WebApi.Repositories;
using System.Threading.Tasks;

namespace Sqorm.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _userRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody]RegisterUserDto userDto)
        {
            await _userRepository.AddAsync(userDto.Username, userDto.Password);
            return Ok();
        }
    }
}