

using ApplicationLayer.GenericInterface;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList
{
    public class GetAppointmentlistQueryHandler : IRequestHandler<GetAppointmentlistQuery, List<AppointmentViewModel>>
    {
        private readonly IGenericRepository<Appointment> _genericRepository;
        private readonly IMapper _mapper;

        public GetAppointmentlistQueryHandler(IGenericRepository<Appointment> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<AppointmentViewModel>> Handle(GetAppointmentlistQuery request, CancellationToken cancellationToken)
        {
            var query= await _genericRepository.GetAll(new[] { "patient", "doctor" } );

             var map= _mapper.Map<List<AppointmentViewModel>>(query);
           
            return map;
        }


    }
}

/*
      how the Handler performs the requested operation?

       Request:
       A request is initiated by the application or a client. It represents an action or query that needs to be processed.
       For example, it could be a command to create a new user or a query to retrieve a list of products.
       
       Mediator:
       The mediator acts as the central coordinator and receives the request.
       It is responsible for identifying the appropriate handler to process the request based on the request type.
       
       Handler:
       Handlers are classes that implement specific interfaces or inherit from base classes provided by MediatR.
       Each handler is responsible for handling a specific type of request. For example,
       you might have a CreateUserHandler to handle requests for creating a new user.
       you might have a UpdateUserHandler to handle requests for Updating a new user.
       
       Handler Method:
       Inside the handler, you define a method that matches the request type. This method contains the logic to perform
       the requested operation. For example, the CreateUserHandler might have a Handle(CreateUserRequest request) method.
       
       Mediator Invoke:
       Once the mediator identifies the appropriate handler, it invokes the corresponding method in the handler,
       passing the request object as a parameter.
       
       Operation Execution:
       The handler method executes the necessary logic to perform the requested operation.
       This can include tasks like data retrieval, business logic processing, data manipulation,
       or interacting with external systems.
       
       Response:
       After the handler completes the requested operation, it returns a response object.
       The response can contain the result of the operation, error information, or any other relevant data.
 */