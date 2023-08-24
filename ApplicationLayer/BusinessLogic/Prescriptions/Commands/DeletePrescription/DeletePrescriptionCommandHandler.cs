

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Prescriptions.Commands.DeletePrescription
{
    public class DeletePrescriptionCommandHandler : IRequestHandler<DeletePrescriptionCommand, Unit>
    {
        private readonly IGenericRepository<Prescription> _genericRepository;

        public DeletePrescriptionCommandHandler(IGenericRepository<Prescription> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(DeletePrescriptionCommand request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);

            if (query == null)
            {
                throw new ArgumentException("this Prescription is not exist");
            }

            await _genericRepository.Delete(query);

            return Unit.Value;
        }
    }
}
