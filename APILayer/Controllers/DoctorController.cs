using ApplicationLayer.BusinessLogic.Doctors.Commands.AddDoctor;
using ApplicationLayer.BusinessLogic.Doctors.Commands.DeleteDoctor;
using ApplicationLayer.BusinessLogic.Doctors.Commands.UpdateDoctor;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorByName;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorBySpeciality;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsByName;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsList;
using AutoMapper;
using DomainLayer.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DoctorController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAllDoctors")]
        public async Task<ActionResult<List<DoctorViewModel>>> GetAllDoctors()
        {
            var query = await _mediator.Send(new GetDoctorListQuery());

            if (query is null)
            {
                return NotFound("Not found Doctors");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDetailViewModel>> GetDoctorById(int id)
        {
            var query = await _mediator.Send(new GetDoctorQuery() { id=id});

            if (query is null)
            {
                return NotFound("this Doctor is not exist");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpGet("Speciality")]
        public async Task<ActionResult<DoctorViewModelBySpeciality>> GetDoctorBySpeciality(Specialty specialty)
        {
            var query = await _mediator.Send(new GetBySpecialityDoctorQuery() { specialty = specialty});

            if (query is null)
            {
                return NotFound("this Doctor is not exist");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> AddDoctor(DoctorViewModel model)
        {
            var query = await _mediator.Send(new AddDoctorCommand());

            if (!ModelState.IsValid)
            {
                return BadRequest("Model state is invalid");
            }

            return Created("", query);
        }


        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Unit>> updateDoctor(UpdateDoctorRequiest model, int id)
        {
            var UpdateDoctorCommand = _mapper.Map<UpdateDoctorCommand>(model);
            UpdateDoctorCommand.Id= id;

            var query = await _mediator.Send(UpdateDoctorCommand);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<Unit>> deleteDoctor(int id)
        {
            var Doctor = new DeleteDoctorCommand() { id = id };

            var query = await _mediator.Send(Doctor);

            return Ok(query);
        }

    }
}
