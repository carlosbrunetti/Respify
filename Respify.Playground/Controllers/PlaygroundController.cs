using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Respify.helpers;
using Respify.Playground.classes;
using Respify.Playground.classes.generator;

namespace Respify.Playground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaygroundController : ControllerBase
    {
        [HttpGet("PaginatedResponse")]
        public async Task<ObjectResult> GetPaginatedResponse()
        {
            var list = CarGenerator.GenerateCarList(2);
            var paginatedResponse = new PaginatedResponse<List<Car>>(list, list.Count, 1, 10, "id", "asc");
            var response =
                ResponseHelper.Success(paginatedResponse, "success",
                    StatusCodes.Status200OK);
            return await response.ToResultAsync();
        }
        
        [HttpGet("NonPaginatedResponse")]
        public async Task<ObjectResult> GetNonPaginatedResponse()
        {
            var cars = CarGenerator.GenerateCarList(2);
            var nonPaginatedResponse = new NonPaginatedResponse<List<Car>>(cars, cars.Count);
            var response =
                ResponseHelper.Success(nonPaginatedResponse, "success",
                    StatusCodes.Status200OK);
            return await response.ToResultAsync();
        }
        
        [HttpPost("CustomResponse")]
        public async Task<ObjectResult> CustomResponse()
        {
            int id = 1;
            var response =
                ResponseHelper.CreateResponse(id, "Created",
                    StatusCodes.Status201Created, true, null);
            return await response.ToResultAsync();
        }
        
        [HttpGet("FailureResponse")]
        public async Task<ObjectResult> GetFailureResponse()
        {
            var errors = new List<string> { "error1", "error2" };
            var response =
                ResponseHelper.Failure<object>(null, null,
                    errors,StatusCodes.Status400BadRequest);
            return await response.ToResultAsync();
        }
        
    }
}
