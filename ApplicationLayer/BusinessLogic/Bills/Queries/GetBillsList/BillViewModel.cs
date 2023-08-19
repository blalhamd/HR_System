using DomainLayer.Enums;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList
{
    public class BillViewModel
    {
        public int Id { get; set; }
        public decimal amount { get; set; }
        public DateTime dateTime { get; set; }
        public StatusBill status { get; set; }
        public int patientId { get; set; }
        public PatientDTO patient { get; set; } = null!;
    }
}
