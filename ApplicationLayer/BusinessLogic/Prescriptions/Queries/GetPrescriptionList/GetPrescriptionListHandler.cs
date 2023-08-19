using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Prescriptions.Queries.GetPrescriptionList
{
    public class GetPrescriptionListHandler : IRequestHandler<GetPrescriptionListQuery, List<PrescriptionViewModel>>
    {
        private readonly IGenericRepository<Prescription> _genericRepository;
        private readonly IMapper _mapper;

        public GetPrescriptionListHandler(IGenericRepository<Prescription> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<PrescriptionViewModel>> Handle(GetPrescriptionListQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetAll(new[] { "appointment" });

            var map = _mapper.Map<List<PrescriptionViewModel>>(query);

            return map;
        }
    }
}
