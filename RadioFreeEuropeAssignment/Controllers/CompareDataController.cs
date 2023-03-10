using Microsoft.AspNetCore.Mvc;
using RadioFreeEuropeAssignment.Models;
using System.Net;

namespace RadioFreeEuropeAssignment.Controllers
{
    [ApiController]
    [Route("v1/diff/{id}")]
    public class CompareDataController : ControllerBase
    {
        public IRepository _repository;
        public CompareDataController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("left")]
        public IActionResult AddLeft(int id, [FromBody] InputData newData)
        {
            //check validation
            Status ValidationResult = _repository.CheckValidation(id, newData);
            if (ValidationResult.Result != Status.Success.Result)
            {
                return BadRequest(ValidationResult.Result);
            }

            //add to the left
            Status statusResult = _repository.Add(id, "left", newData);
            if (statusResult.Result != Status.Success.Result)
            {
                return BadRequest(statusResult.Result);
            }

            return Ok(Status.Success);
        }
        [HttpPost("right")]
        public IActionResult AddRight(int id, [FromBody] InputData newData)
        {
            //check validation
            Status ValidationResult = _repository.CheckValidation(id, newData);
            if (ValidationResult.Result != Status.Success.Result)
            {
                return BadRequest(ValidationResult.Result);
            }

            //add to the left
            Status statusResult = _repository.Add(id, "right", newData);
            if (statusResult.Result != Status.Success.Result)
            {
                return BadRequest(statusResult.Result);
            }

            return Ok(Status.Success);
        }
        [HttpGet]
        public IActionResult GetDiff(int id)
        {
            Result result = _repository.Diff(id);
            return Ok(result);
        }
    }
}