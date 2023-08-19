

using DomainLayer.Enums;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.UpdateBill
{
    public class UpdateBillRequiest
    {
        public decimal amount { get; set; }
        public DateTime dateTime { get; set; }
        public StatusBill status { get; set; }
        public int patientId { get; set; }
    }
}
