

using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorByName;
using DomainLayer.Enums;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorBySpeciality
{
    public class GetBySpecialityDoctorQuery : IRequest<DoctorViewModelBySpeciality>
    {
        public Specialty? specialty { get; set; }
    }
}
