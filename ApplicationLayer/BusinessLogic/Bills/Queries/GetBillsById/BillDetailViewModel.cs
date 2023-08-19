

using ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList;
using DomainLayer.Entities;
using DomainLayer.Enums;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsById
{
    public class BillDetailViewModel
    {
        public int Id { get; set; }
        public decimal amount { get; set; }
        public DateTime dateTime { get; set; }
        public StatusBill status { get; set; }
        public int patientId { get; set; }
        public PatientDTO patient { get; set; }

    }
}
