

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentHandler : IRequestHandler<DeleteAppointmentCommand, Unit>
    {
        private readonly IGenericRepository<Appointment> _repository;

        public DeleteAppointmentHandler(IGenericRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {

            var query = await _repository.GetById(request.Id);

            if (query == null)
            {
                throw new ArgumentException("this appintment is not exist");
            }

            await _repository.Delete(query);

            return Unit.Value;
        }
    }
}
