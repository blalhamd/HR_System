

using ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList;
using DomainLayer.Enums;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Appointments.Commands.AddAppointment
{
    public class AddAppointmentCommand : IRequest<int>
    {
        public DateTime dateTime { get; set; }
        public StatusAppointment status { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
    }
}
