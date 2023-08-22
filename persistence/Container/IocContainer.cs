

using ApplicationLayer.GenericInterface;
using ApplicationLayer.NonGenericInterface;
using Microsoft.Extensions.DependencyInjection;
using persistence.Infrastructure.Repositories;

namespace persistence.Container
{
    public static class IocContainer
    {
        public static IServiceCollection Services(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IDoctorRepository), typeof(DoctorRepository));
            
            return services;
        }
    }
}

/*
    what is the difference between AddTransient and AddScoped?
     
    .The difference between transient and scoped services is that transient services are created and disposed
      of every time they are requested, while scoped services are created once and reused for the duration of the current scope.    

    .Transient services are better for services that do not need to maintain state between requests.
      For example, a transient service might be used to create a new database connection for each request.

    .Scoped services are better for services that need to maintain state between requests. For example,
     a scoped service might be used to create a session object that is shared by all requests in the same session.


     Feature	           Transient	                                                          Scoped
     Creation	    Created and disposed of every time it is requested	         Created once and reused for the duration of the current scope
     State	        Does not maintain state between requests                     Maintains state between requests
     Efficiency	    More lightweight and efficient	                             Less lightweight and efficient
     Convenience	Less convenient to use	                                     More convenient to use
                                                                           
 */
