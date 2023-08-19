

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentById
{
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, AppointmentDetailViewModel>
    {
        private readonly IGenericRepository<Appointment> _genericRepository;
        private readonly IMapper _mapper;

        public GetAppointmentQueryHandler(IGenericRepository<Appointment> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentDetailViewModel> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            var query = await _genericRepository.GetById(request.id);

            var map= _mapper.Map<AppointmentDetailViewModel>(query);

            return map;
        }


    }
}

/*
    what is IRequistHandler?
   
   IRequestHandler is Generic interface will take two types (Request,Response)
 */
