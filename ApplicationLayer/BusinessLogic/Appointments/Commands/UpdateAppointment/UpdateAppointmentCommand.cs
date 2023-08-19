

using ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList;
using DomainLayer.Enums;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public StatusAppointment status { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
    }
}
