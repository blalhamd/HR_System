

using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsById
{
    public class GetBillQuery : IRequest<BillDetailViewModel>
    {
        public int id { get; set; }

    }
}
