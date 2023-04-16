using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjWebAPI16042023.Models;
using ProjWebAPI16042023.Services;

namespace ProjWebAPI16042023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpPost(Name = "Insert")]
        public ActionResult Insert(Car car)
        {
            if (new CarService().insert(car))
                return StatusCode(200);
            return BadRequest();
        }

        [HttpGet(Name = "FindAll")]
        public List<Car> FindAll()
        {
            return new CarService().FindAll();
        }
    }
}
