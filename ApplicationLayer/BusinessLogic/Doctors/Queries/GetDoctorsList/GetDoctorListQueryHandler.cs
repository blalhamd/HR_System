using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsList
{
    public class GetDoctorListQueryHandler : IRequestHandler<GetDoctorListQuery, List<DoctorViewModel>>
    {
        private readonly IGenericRepository<Doctor> _genericRepository;
        private readonly IMapper _mapper;

        public GetDoctorListQueryHandler(IGenericRepository<Doctor> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<DoctorViewModel>> Handle(GetDoctorListQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetAll();

            var map = _mapper.Map<List<DoctorViewModel>>(query);

            return map;
        }
    }
}
