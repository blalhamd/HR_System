

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Doctors.Commands.AddDoctor
{
    public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, int>
    {
        private readonly IGenericRepository<Doctor> _repository;
        private readonly IMapper _mapper;

        public AddDoctorCommandHandler(IGenericRepository<Doctor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var map= _mapper.Map<Doctor>(request);

            await _repository.Add(map);

            return map.Id;
        }

    }
}
