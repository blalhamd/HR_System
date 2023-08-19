

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsByName
{
    public class GetDoctorHandler : IRequestHandler<GetDoctorQuery, DoctorDetailViewModel>
    {
        private readonly IGenericRepository<Doctor> _genericRepository;
        private readonly IMapper _mapper;

        public GetDoctorHandler(IGenericRepository<Doctor> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<DoctorDetailViewModel> Handle(GetDoctorQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);

            var map= _mapper.Map<DoctorDetailViewModel>(query);

            return map;
        }
    }
}
