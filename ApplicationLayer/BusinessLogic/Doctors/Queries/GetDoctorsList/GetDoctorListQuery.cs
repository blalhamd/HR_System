using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsList
{
    public class GetDoctorListQuery : IRequest<List<DoctorViewModel>>
    {

    }
}
