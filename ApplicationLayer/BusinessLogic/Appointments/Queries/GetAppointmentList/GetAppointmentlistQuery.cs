

using MediatR;

namespace ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList
{
    public class GetAppointmentlistQuery : IRequest<List<AppointmentViewModel>>
    {

    }
}

// query will recive it to Handler


