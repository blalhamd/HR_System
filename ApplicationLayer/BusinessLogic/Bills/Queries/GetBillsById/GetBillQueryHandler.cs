

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsById
{
    public class GetBillQueryHandler : IRequestHandler<GetBillQuery, BillDetailViewModel>
    {
        private readonly IGenericRepository<Bill> _genereicRepository;
        private readonly IMapper _mapper;

        public GetBillQueryHandler(IGenericRepository<Bill> genereicRepository, IMapper mapper)
        {
            _genereicRepository = genereicRepository;
            _mapper = mapper;
        }

        public async Task<BillDetailViewModel> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            var query = await _genereicRepository.GetById(request.id);

            var map= _mapper.Map<BillDetailViewModel>(query);

            return map;
        }
    }
}
