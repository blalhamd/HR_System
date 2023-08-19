

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Appointments.Commands.AddAppointment
{
    public class AddAppointmentHandler : IRequestHandler<AddAppointmentCommand, int>
    {
        private readonly IGenericRepository<Appointment> _repository;
        private readonly IMapper _mapper;

        public AddAppointmentHandler(IGenericRepository<Appointment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            var map= _mapper.Map<Appointment>(request);
            
            var query= await _repository.Add(map);

            return query.Id;
        }
    }
}
