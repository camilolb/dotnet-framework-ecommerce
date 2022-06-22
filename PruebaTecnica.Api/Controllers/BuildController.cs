using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Responses;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;
using PruebaTecnica.Core.QueryFilters;

namespace PruebaTecnica.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BuildController : ControllerBase
    {
        private readonly IBuildService _BuildService;

        public BuildController(IBuildService BuildService)
        {
            _BuildService = BuildService;
        }



        [HttpGet("getFilter")]
        public IActionResult GetFilter([FromQuery] BuildQueryFilter filterQuery)
        {
            try
            {
                var service = _BuildService.BuildFilter(filterQuery);
                var response = new ApiResponse<IEnumerable<Build>>(service);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new APIError { Version = "1.0", ErrorMessage = ex.Message, StatusCode = "500" });
            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var service = _BuildService.Gets();
                var response = new ApiResponse<IEnumerable<Build>>(service);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new APIError { Version = "1.0", ErrorMessage = ex.Message, StatusCode = "500" });
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var service = await _BuildService.Get(id);
                var response = new ApiResponse<Build>(service);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new APIError { Version = "1.0", ErrorMessage = ex.Message, StatusCode = "500" });
            }
        }




        [HttpGet("buildAndDepartaments")]
        public IActionResult BuildAndDepartaments(int id)
        {
            try
            {
                var service = _BuildService.BuildAndDepartaments(id);
                var response = new ApiResponse<IEnumerable<Build>>(service);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new APIError { Version = "1.0", ErrorMessage = ex.Message, StatusCode = "500" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Build item)
        {
            try
            {
                await _BuildService.Insert(item);
                var response = new ApiResponse<Build>(item);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new APIError { Version = "1.0", ErrorMessage = ex.Message, StatusCode = "500" });
            }
        }

        [HttpPut]
        public IActionResult Put(int id, Build item)
        {
            try
            {
                item.Id = id;
                _BuildService.Update(item);
                var response = new ApiResponse<bool>(true);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new APIError { Version = "1.0", ErrorMessage = ex.Message, StatusCode = "500" });
            }
        }

    }
}