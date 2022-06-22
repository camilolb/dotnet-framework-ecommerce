using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaTecnica.Api.Responses;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _userService;
        private readonly IConfiguration _configuration;


        public SecurityController(ISecurityService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;

        }

        [HttpPost("{login}")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            try
            {
                var service = await _userService.Get(userName, password);
                service.Token = new Jwt(_configuration).GenerateToken(service);

                Response.Cookies.Append("jwt", service.Token, new CookieOptions
                {
                    HttpOnly = true
                });

                var response = new ApiResponse<Security>(service);
                return Ok(response);
            }
            catch (System.Exception)
            {
                return Unauthorized();
            }
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var service = await _userService.Get(id);
            var response = new ApiResponse<Security>(service);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Security item)
        {
            await _userService.Insert(item);
            var response = new ApiResponse<Security>(item);
            return Ok(response);
        }


        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put(int id, Security item)
        {
            item.Id = id;
            var result = await _userService.Update(item);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        /*
        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }*/


    }
}