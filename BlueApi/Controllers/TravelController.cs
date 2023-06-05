using Dal.Model;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Net.Mime;
using System.Text;

namespace BlueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelRepository<Travel> repository;
        public TravelController(ITravelRepository<Travel> repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public IActionResult GetTravel()
        {
            try
            {


                return Ok(repository.Get());

            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                return Ok(repository.Get(id));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpPost]
        public IActionResult AddTravel([FromBody] Travel travel)
        {
            var Results = repository.Add(travel);
            if (Results != null)
            {
                return Ok("Succesfully added");
            }
            else
            {
                return BadRequest("failed");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTravel([FromRoute] int id)
        {
            var Results = repository.Delete(id);
            if (Results != null)
            {
                return Ok("Succesfully deleted");
            }
            else
            {
                return NotFound("failed");
            }
        }

        [HttpGet("GetByArrival")]
        public IActionResult GetByArrival([FromQuery] string arrival)
        {
            try
            {
                return Ok(repository.GetByArrival(arrival));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpGet("GetByDeparture")]
        public IActionResult GetByDeparture([FromQuery] string Departure)
        {
            try
            {
                return Ok(repository.GetByDeparture(Departure));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpGet("GetByDepartureArrivalAndPassengers")]
        public IActionResult GetByDepartureArrivalAndPassengers([FromQuery] string arrival, [FromQuery] string Departure, [FromQuery] int Passengers)
        {
            try
            {
                return Ok(repository.GetByDepartureArrivalAndPassengers(Departure, arrival, Passengers));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTravel([FromBody] Travel travel, [FromRoute] int id)
        {
            try
            {
                return Ok(repository.Update(travel, id));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpGet("file/{id}")]
        public IActionResult GetTravelFile([FromRoute] int id)
        {
            try
            {
                FileSettings file_settings = repository.GenerateFile(id);
                var fileContents = Encoding.UTF8.GetBytes(file_settings.FileContent.ToString());
                var contentType = "text/plain";
                var contentDisposition = new ContentDisposition
                {
                    FileName = file_settings.Name.ToString(),
                    Inline = false
                };
                Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

                return new FileContentResult(fileContents, contentType);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
