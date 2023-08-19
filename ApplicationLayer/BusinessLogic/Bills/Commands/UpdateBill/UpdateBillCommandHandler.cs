

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.UpdateBill
{
    public class UpdateBillCommandHandler : IRequestHandler<UpdateBillCommand, Unit>
    {
        private readonly IGenericRepository<Bill> _genericRepository;
        private readonly IMapper _mapper;

        public UpdateBillCommandHandler(IGenericRepository<Bill> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBillCommand request, CancellationToken cancellationToken)
        {
            var map= _mapper.Map<Bill>(request);

            await _genericRepository.Update(map);

            return Unit.Value;
        }
    }
}
