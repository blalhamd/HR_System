
using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.AddBill
{
    public class AddBillCommandHandler : IRequestHandler<AddBillCommand, int>
    {
        private readonly IGenericRepository<Bill> _genericRepository;
        private readonly IMapper _mapper;

        public AddBillCommandHandler(IGenericRepository<Bill> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddBillCommand request, CancellationToken cancellationToken)
        {
            var map= _mapper.Map<Bill>(request);

            await _genericRepository.Add(map);

            return map.Id;
        }
    }
}
