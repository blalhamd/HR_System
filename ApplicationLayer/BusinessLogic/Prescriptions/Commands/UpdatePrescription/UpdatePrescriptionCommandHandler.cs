

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Prescriptions.Commands.UpdatePrescription
{
    public class UpdatePrescriptionCommandHandler : IRequestHandler<UpdatePrescriptionCommand, Unit>
    {
        private readonly IGenericRepository<Prescription> _genericRepository;
        private readonly IMapper _mapper;

        public UpdatePrescriptionCommandHandler(IGenericRepository<Prescription> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePrescriptionCommand request, CancellationToken cancellationToken)
        {
           
            var map = _mapper.Map<Prescription>(request);

            await _genericRepository.Update(map);

            return Unit.Value;
        }
    }
}
