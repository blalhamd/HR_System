

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.AddPatient
{
    public class AddPatiendCommandHandler : IRequestHandler<AddPatientCommand, int>
    {
        private readonly IGenericRepository<Patient> _genericRepository;
        private readonly IMapper _mapper;

        public AddPatiendCommandHandler(IGenericRepository<Patient> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Patient>(request);

            await _genericRepository.Add(map);

            return map.Id;
        }
    }
}
