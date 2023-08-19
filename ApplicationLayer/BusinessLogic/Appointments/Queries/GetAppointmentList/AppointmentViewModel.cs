

using DomainLayer.Entities;
using DomainLayer.Enums;

namespace ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList
{
    public class AppointmentViewModel 
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public StatusAppointment status { get; set; }
        public int patientId { get; set; }
        public PatientDTO patient { get; set; } = null!;
        public int doctorId { get; set; }
        public DoctorDTO doctor { get; set; } = null!;
    }
}

// that view for displaying to the client
