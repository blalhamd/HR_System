

using ApplicationLayer.BusinessLogic.Appointments.Queries.GetAppointmentList;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace ApplicationLayer.ApplicationContainer
{
    public static class Container
    {
        public static IServiceCollection Services(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }


    }
}

/*
      what is automapper and why use it?

      .AutoMapper simplifies the conversion of data between different types of objects,such as models and view models.
       

      what is MediatR and why use it?

          . is a design pattern that decouples communication between objects(Layers). This makes it easier to test and maintain the code
            

      what is mediatR's work flow?
     
       1- A client sends a request to the mediator.
       2- The mediator finds the appropriate(المناسب) handler for the request. 
       3- The mediator invokes the handler.
       4- The handler performs the requested operation.
       5- The handler returns a response to the mediator.
       6- The mediator returns the response to the client.


     What problems does MediatR solve?
 
     MediatR solves the problem of tightly coupled code. 
     Tightly coupled code is code where objects are tightly interdependent.
     This can make the code difficult to test, maintain, and change.
     MediatR solves this problem by decoupling objects and allowing them to communicate through a central point.


      what is CQRS and why use it?
      
      is architectural design pattern for seperation Queries(GetAll,GetById,GetByName,etc) and Commands(Update,delete,create) from data store.
      that help us for single responsibiliy,maintainability,easy to extend extend.
      when use it? when to want to separate between Queries and commands.


      The code uses the Services method to register the AutoMapper and MediatR services in the IServiceCollection, 
      which is an interface that represents a collection of service descriptors.
      
      The method calls the AddAutoMapper extension method with the current assembly as an argument,
      which scans the assembly for profiles that define the mapping rules.
      The method also calls the AddMediatR extension method with the current assembly as an argument,
      which registers all the handlers and requests in the assembly.
      
      The Services method returns the modified IServiceCollection,
      which can be used by other parts of the program to resolve dependencies.
 */

