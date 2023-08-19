

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientById
{
    public class GetPatientHandler : IRequestHandler<GetPatientQuery, PatientDetailViewModel>
    {
        private readonly IGenericRepository<Patient> _genericRepository;
        private readonly IMapper _mapper;

        public GetPatientHandler(IGenericRepository<Patient> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<PatientDetailViewModel> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);

            var map= _mapper.Map<PatientDetailViewModel>(query);

            return map;
        }


    }
}
