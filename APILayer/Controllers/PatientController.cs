using ApplicationLayer.BusinessLogic.Patients.Commands.AddPatient;
using ApplicationLayer.BusinessLogic.Patients.Commands.DeletePatient;
using ApplicationLayer.BusinessLogic.Patients.Commands.UpdatePatient;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientById;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientDetailViewModel = ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientById.PatientDetailViewModel;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PatientController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAllPatients")]
        public async Task<ActionResult<List<PatientDetailViewModel>>> GetAllPatients()
        {
            var query = await _mediator.Send(new GetPatientListQuery());

            if (query is null)
            {
                return NotFound("Not found Patients");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDetailViewModel>> GetPatientById(int id)
        {
            var query = await _mediator.Send(new GetPatientQuery() { id=id});

            if (query is null)
            {
                return NotFound("this Patient is not exist");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> AddPatient(PatientDetailViewModel model)
        {
            var query = await _mediator.Send(new AddPatientCommand());

            if (!ModelState.IsValid)
            {
                return BadRequest("Model state is invalid");
            }

            return Created("", query);
        }



        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Unit>> updatePatient(UpdatePatientRequiest model, int id)
        {
            var UpdatePatientRequiest = _mapper.Map<UpdatePatientCommand>(model);
            UpdatePatientRequiest.Id = id;

            var query = await _mediator.Send(UpdatePatientRequiest);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<Unit>> deletePatient(int id)
        {
            var Patient = new DeletePatientCommand() { id = id };

            var query = await _mediator.Send(Patient);

            return Ok(query);
        }

    }
}
