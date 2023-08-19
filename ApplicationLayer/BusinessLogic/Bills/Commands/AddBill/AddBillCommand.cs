

using DomainLayer.Enums;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.AddBill
{
    public class AddBillCommand : IRequest<int>
    {
        public decimal amount { get; set; }
        public DateTime dateTime { get; set; }
        public StatusBill status { get; set; }
        public int patientId { get; set; }
    }
}
