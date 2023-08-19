

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Prescriptions.Queries.GetPrescriptionById
{
    public class GetPrescriptionQueryHandler : IRequestHandler<GetPrescriptionQuery, PrescriptionDetailViewModel>
    {
        private readonly IGenericRepository<Prescription> _genericRepository;
        private readonly IMapper _mapper;

        public GetPrescriptionQueryHandler(IGenericRepository<Prescription> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<PrescriptionDetailViewModel> Handle(GetPrescriptionQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);
            
            var map= _mapper.Map<PrescriptionDetailViewModel>(query);

            return map;
        }
    }
}
