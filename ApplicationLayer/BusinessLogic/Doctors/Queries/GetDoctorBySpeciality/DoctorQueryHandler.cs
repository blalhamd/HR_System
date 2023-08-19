

using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorBySpeciality;
using ApplicationLayer.NonGenericInterface;
using AutoMapper;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorByName
{
    public class DoctorQueryHandler : IRequestHandler<GetBySpecialityDoctorQuery,DoctorViewModelBySpeciality>
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public DoctorQueryHandler(IDoctorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DoctorViewModelBySpeciality> Handle(GetBySpecialityDoctorQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetDoctorBySpeciality(request.specialty);

            if (query == null)
            {
                throw new Exception("Not exist");
            }

            var map = _mapper.Map<DoctorViewModelBySpeciality>(query);

            return map;
        }
    }
}
