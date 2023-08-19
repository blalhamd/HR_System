using ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList;
using DomainLayer.Entities;
using DomainLayer.Enums;

namespace ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentById
{
    // this view Model will display to end user
    public class AppointmentDetailViewModel
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public StatusAppointment status { get; set; }
        public int patientId { get; set; }
        public PatientDTO patient { get; set; }
        public int doctorId { get; set; }
        public DoctorDTO doctor { get; set; }
    }
}
