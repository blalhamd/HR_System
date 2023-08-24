

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, Unit>
    {
        private readonly IGenericRepository<Doctor> _genericRepository;

        public DeleteDoctorCommandHandler(IGenericRepository<Doctor> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);

            if (query == null)
            {
                throw new ArgumentException("this doctor is not exist");
            }

            await _genericRepository.Delete(query);

            return Unit.Value;
        }
    }
}
