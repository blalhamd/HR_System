using ApplicationLayer.BusinessLogic.Prescriptions.Commands.AddPrescription;
using ApplicationLayer.BusinessLogic.Prescriptions.Commands.DeletePrescription;
using ApplicationLayer.BusinessLogic.Prescriptions.Commands.UpdatePrescription;
using ApplicationLayer.BusinessLogic.Prescriptions.Queries.GetPrescriptionById;
using ApplicationLayer.BusinessLogic.Prescriptions.Queries.GetPrescriptionList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetAllPrescriptions")]
        public async Task<ActionResult<List<PrescriptionViewModel>>> GetAllPrescriptions()
        {
            var query = await _mediator.Send(new GetPrescriptionListQuery());

            if (query is null)
            {
                return NotFound("Not found Prescriptions");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<PrescriptionDetailViewModel>> GetPrescriptionById(int id)
        {
            var query = await _mediator.Send(new GetPrescriptionQuery() { id=id});

            if (query is null)
            {
                return NotFound("this Prescription is not exist");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> AddPrescription(PrescriptionViewModel model)
        {
            var query = await _mediator.Send(new AddPrescriptionCommand());

            if (!ModelState.IsValid)
            {
                return BadRequest("Model state is invalid");
            }

            return Created("", query);
        }


        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Unit>> updatePrescription(UpdatePrescriptionCommand command)
        {

            var query = await _mediator.Send(command);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<Unit>> deletePrescription(int id)
        {
            var Prescription = new DeletePrescriptionCommand() { id = id };

            var query = await _mediator.Send(Prescription);

            return Ok(query);
        }


    }
}

/*


  "userName": "Bilal3Sayed",
  "password": "89223116&Mo3ez",
  "confirmPassword": "89223116&Mo3ez",
  "email": "Bilal@gmail.com"
}'
 */
