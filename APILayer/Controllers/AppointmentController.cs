using ApplicationLayer.BusinessLogic.Appointments.Commands.AddAppointment;
using ApplicationLayer.BusinessLogic.Appointments.Commands.DeleteAppointment;
using ApplicationLayer.BusinessLogic.Appointments.Commands.UpdateAppointment;
using ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentById;
using ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppointmentViewModel = ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList.AppointmentViewModel;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AppointmentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAllAppointments")]
        public async Task<ActionResult<List<AppointmentViewModel>>> GetAllApointments()
        {
            var query = await _mediator.Send(new GetAppointmentlistQuery());

            if(query is null)
            {
                return NotFound("Not found Appointments");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailViewModel>> GetAppointmentById(int id)
        {
            var query = await _mediator.Send(new GetAppointmentQuery() { id=id});
            
            if(query is null)
            {
                return NotFound("this Appoinment is not exist");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> AddAppointment(AppointmentViewModel model)
        {
            var query = await _mediator.Send(new AddAppointmentCommand());

            if(! ModelState.IsValid)
            {
                return BadRequest("Model state is invalid");
            }

            return Created("",query);
        }



        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Unit>> updateAppointment(UpdateAppointmentRequist model,int id)
        {
            var UpdateAppointmentCommand = _mapper.Map<UpdateAppointmentCommand>(model);
            UpdateAppointmentCommand.Id= id;

            var query= await _mediator.Send(UpdateAppointmentCommand);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<Unit>> deleteAppointment(int id)
        {
            var Appointment = new DeleteAppointmentCommand() { Id = id };

            var query = await _mediator.Send(Appointment);

            return Ok(query);
        }


    }
}

