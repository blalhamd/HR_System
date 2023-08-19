

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Commands.DeleteBill
{
    public class DeleteBillCommandHandler : IRequestHandler<DeleteBillCommand, Unit>
    {
        private readonly IGenericRepository<Bill> _genericRepository;
        private readonly IMapper _mapper;

        public DeleteBillCommandHandler(IGenericRepository<Bill> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBillCommand request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);
           
            if (query == null)
            {
                throw new ArgumentException("this is not exist");
            }

            await _genericRepository.Delete(query);

            return Unit.Value;
        }
    }
}
