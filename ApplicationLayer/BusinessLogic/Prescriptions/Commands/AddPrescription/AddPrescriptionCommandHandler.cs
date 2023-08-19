

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Prescriptions.Commands.AddPrescription
{
    public class AddPrescriptionCommandHandler : IRequestHandler<AddPrescriptionCommand, int>
    {
        private readonly IGenericRepository<Prescription> _genericRepository;
        private readonly IMapper _mapper;

        public AddPrescriptionCommandHandler(IGenericRepository<Prescription> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddPrescriptionCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Prescription>(request);

            await _genericRepository.Add(map);

            return map.Id;
        }
    }
}
