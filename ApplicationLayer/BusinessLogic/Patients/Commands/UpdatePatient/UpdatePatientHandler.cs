

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.UpdatePatient
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Unit>
    {
        private readonly IGenericRepository<Patient> _genericRepository;
        private readonly IMapper _mapper;

        public UpdatePatientHandler(IGenericRepository<Patient> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var map= _mapper.Map<Patient>(request);

            await _genericRepository.Update(map);

            return Unit.Value;
        }
    }
}
