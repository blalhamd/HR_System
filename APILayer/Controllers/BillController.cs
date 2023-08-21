using ApplicationLayer.BusinessLogic.Bills.Commands.AddBill;
using ApplicationLayer.BusinessLogic.Bills.Commands.DeleteBill;
using ApplicationLayer.BusinessLogic.Bills.Commands.UpdateBill;
using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsById;
using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("GetAllBills")]
        public async Task<ActionResult<List<BillViewModel>>> GetAllBills()
        {
            var query = await _mediator.Send(new GetBillListQuery());

            if (query is null)
            {
                return NotFound("Not found Bills");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<BillDetailViewModel>> GetBillById(int id)
        {
            var query = await _mediator.Send(new GetBillQuery() { id = id });

            if (query is null)
            {
                return NotFound("this Bill is not exist");
            }

            return Ok(query);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> AddBill(AddBillCommand model)
        {
            var query = await _mediator.Send(model);

            if (!ModelState.IsValid)
            {
                return BadRequest("Model state is invalid");
            }

            return Created("", query);
        }



        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Unit>> updateBill(UpdateBillCommand command)
        {

            var query = await _mediator.Send(command);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> deleteBill(int id)
        {

            var query = await _mediator.Send(new DeleteBillCommand() { id = id });

            return Ok(query);
        }

    }
}
