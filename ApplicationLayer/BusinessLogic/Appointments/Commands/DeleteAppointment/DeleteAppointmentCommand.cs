

using MediatR;

namespace ApplicationLayer.BusinessLogic.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
