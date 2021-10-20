using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YouFindAssessment.BusinessLogic.IServices.IHotelService;

namespace YouFindAssessment.Task3.Controllers
{
    [Route("[controller]/[action]/{id:int}")]
    [ApiController]
    public class HotelRatesController : ControllerBase
    {
        private readonly IHotelRatesService _service;

        public HotelRatesController(IHotelRatesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetHotelRates(int id, [FromQuery] DateTime arrivalDate)
        {
            try
            {
                //get filtered hotel rates
                var result = _service.GetHotelRates(id, arrivalDate);
                if (result.hotelRates.Count == 0)
                {
                    return NotFound($"There is no available rate at {arrivalDate.ToShortDateString()}");
                }
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.ParamName);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something wrong happened!");
            }

        }
    }
}
