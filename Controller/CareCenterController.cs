using Microsoft.AspNetCore.Mvc;
using CareCenterApi.Service;
using CareCenterApi.Model;

namespace CareCenterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CareCenterController : ControllerBase
    {
        private readonly ICareCenterService _careCenterService;

        public CareCenterController(ICareCenterService careCenterService)
        {
            _careCenterService = careCenterService;
        }


//ADD PET
         [HttpPost("AddPet")]
        public IActionResult AddPet([FromBody] Pet pet)
        {
            if (pet == null)
            {
                return BadRequest("Pet data is null.");
            }

            _careCenterService.AddPet(pet);
            return Ok("Pet added successfully.");
        }

        [HttpGet("GetPet/{name}")]
        public IActionResult GetPet(string name)
        {
            var pet = _careCenterService.GetPetByName(name);
            if (pet == null)
            {
            return NotFound("Pet not found.");
            }

            return Ok(pet);
        }

//ADD CHILD

        [HttpPost("AddChild")]
        public IActionResult AddChild([FromBody] Child child)
        {
            if (child == null)
            {
                return BadRequest("Child data is null.");
            }

            _careCenterService.AddChild(child);
            return Ok("Child added successfully.");
        }

        [HttpGet("GetChild/{name}")]
        public IActionResult GetChild(string name)
        {
            var child = _careCenterService.GetChildByName(name);
            if (child == null)
            {
            return NotFound("Child not found.");
            }

            return Ok(child);
        }
//ADD ELDERLY

        [HttpPost("AddElderly")]
        public IActionResult AddElderly([FromBody] Elderly elderly)
        {
            if (elderly == null)
            {
                return BadRequest("Elderly data is null.");
            }

            _careCenterService.AddElderly(elderly);
            return Ok("Elderly added successfully.");
        }

        [HttpGet("GetElderly/{name}")]
        public IActionResult GetElderly(string name)
        {
            var elderly = _careCenterService.GetElderlyByName(name);
            if (elderly == null)
            {
            return NotFound("Elderly person not found.");
            }

            return Ok(elderly);
        }
//ADD SPECIAL NEED

        [HttpPost("AddSpecial")]
        public IActionResult AddSpecial([FromBody] SpecialNeed specialNeed)
        {
            if (specialNeed == null)
            {
                return BadRequest("Special Need data is null.");
            }

            _careCenterService.AddSpecial(specialNeed);
            return Ok("Special Need added successfully.");
        }

        [HttpGet("GetSpecial/{name}")]
        public IActionResult GetSpecial(string name)
        {
            var specialNeed = _careCenterService.GetSpecialByName(name);
            if (specialNeed == null)
            {
            return NotFound("Special Need person not found.");
            }

            return Ok(specialNeed);
        }
//ADD APPOINTMENT

        [HttpPost("AddAppointment")]
        public IActionResult AddAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Appointment data is null.");
            }

            _careCenterService.AddAppointment(appointment);
            return Ok("Appointment added successfully.");
        }

        [HttpGet("GetBookingDetail/{name}/{careType}")]
        public IActionResult GetBookingDetail(string name, string careType)
        {
            var bookingDetail = _careCenterService.GetBookingDetail(name, careType);
            if (bookingDetail == null)
            {
            return NotFound("Booking Detail not found.");
            }

            return Ok(bookingDetail);
        }

    }
}