

using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.DeleteBill
{
    public class DeleteBillCommand : IRequest<Unit>
    {
        public int id { get; set; }
    }
}
