

using MediatR;

namespace ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentById
{
    public class GetAppointmentQuery : IRequest<AppointmentDetailViewModel>
    {
        public int id { get; set; }

    }
}
