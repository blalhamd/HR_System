

using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsByName
{
    public class GetDoctorQuery : IRequest<DoctorDetailViewModel>
    {
        public int id { get; set; }
    }
}
