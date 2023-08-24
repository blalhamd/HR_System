

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Patients.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, Unit>
    {
        private readonly IGenericRepository<Patient> _repository;

        public DeletePatientCommandHandler(IGenericRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetById(request.id);

            if (query == null)
            {
                throw new ArgumentException("this patien is not exist");
            }

            await _repository.Delete(query);
            
            return Unit.Value;
        }
    }
}
