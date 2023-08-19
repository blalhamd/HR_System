

using DomainLayer.Enums;

namespace ApplicationLayer.BusinessLogic.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentRequist
    {
        public DateTime dateTime { get; set; }
        public StatusAppointment status { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
    }
}
