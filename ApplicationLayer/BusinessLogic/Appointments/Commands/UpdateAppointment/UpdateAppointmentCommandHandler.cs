

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand>
    {
        private readonly IGenericRepository<Appointment> _genericRepository;
        private readonly IMapper _mapper;

        public UpdateAppointmentCommandHandler(IGenericRepository<Appointment> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Appointment>(request);

            await _genericRepository.Update(map);

            return Unit.Value;
        }
    }
}
