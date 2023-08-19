using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList
{
    public class GetBillListQuery : IRequest<List<BillViewModel>>
    {

    }
}
