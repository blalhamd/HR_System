

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, Unit>
    {
        private readonly IGenericRepository<Doctor> _genericRepository;
        private readonly IMapper _mapper;

        public UpdateDoctorCommandHandler(IGenericRepository<Doctor> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var map= _mapper.Map<Doctor>(request);

            await _genericRepository.Update(map);

            return Unit.Value;
        }
    }
}
