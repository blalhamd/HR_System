using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList
{
    public class GetBillListQueryHandler : IRequestHandler<GetBillListQuery, List<BillViewModel>>
    {
        private readonly IGenericRepository<Bill> _genericRepository;
        private readonly IMapper _mapper;

        public GetBillListQueryHandler(IGenericRepository<Bill> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<BillViewModel>> Handle(GetBillListQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetAll(new[] { "patient" });

            var map = _mapper.Map<List<BillViewModel>>(query);

            return map;
        }
    }
}
