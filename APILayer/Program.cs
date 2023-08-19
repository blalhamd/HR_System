using Microsoft.OpenApi.Models;
using persistence.Container;
using ApplicationLayer.ApplicationContainer;
using persistence.APPDBCONTEXT;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using persistence.Identity;
using System.Security.Principal;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
 builder.Services.AddControllers(): This is like adding a feature to your app that allows you
   to handle different requests,For example, you can have controllers to create, update, or delete.

.AddJsonOptions(options => { ... }): This part is like customizing how your app handles the data related.
  In our case, we're interested in how JSON data is handled.

options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
: This line specifically tells the app's JSON serializer to preserve references when converting objects
to JSON.
 */
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});


//is configuring Identity to use your custom user class, role class, and database context.
//AddEntityFrameworkStores<AppDbContext>(): This method tells Identity to use the AppDbContext class to store user data.

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();




//[Authoriz] used JWT Token in Chck Authantiaction
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudiance"],
        IssuerSigningKey =
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/*
  Swagger is a popular open-source framework that provides a set of tools for designing,
  building, documenting, and consuming APIs. It includes a user-friendly interface that
  allows developers to visualize and interact with the API endpoints, view request and response schemas,
  test the API.
 */
builder.Services.AddSwaggerGen(

    c => {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "My API",
            Version = "v1"
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    });



var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(connectionString));

Container.Services(builder.Services);

IocContainer.Services(builder.Services);


/*
 CORS is a mechanism that allows web browsers to make cross-origin requests,
 meaning requests from one domain to another. By default, web browsers restrict such requests
 due to security reasons. However, if you want to allow your application to receive requests 
 from different domains, you need to configure CORS.
 */

builder.Services.AddCors(corsOptions => {
    corsOptions.AddPolicy("MyPolicy", corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


/*
 completes the configuration process and creates an instance of your application,
 which is then used to start and run the application, enabling it to handle incoming requests.
 without it? your application won't be properly set up and won't be able to handle incoming requests.
 */
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*
 * s a way of adding middleware to the request pipeline, which is a series of components that
 * handle requests and responses in a web application. Middleware are classes that have access to
 * the request and response objects and can perform some logic or action before passing them to
 * the next component in the pipeline. The method UseHttpsRedirection adds a middleware that redirects
 * HTTP requests to HTTPS, which is a more secure protocol for transferring data over the internet.
 which improves the security and privacy of the web application. By redirecting HTTP requests to HTTPS,
 the method ensures that the data exchanged between the client and the server is encrypted and
 authenticated, which prevents unauthorized access, modification or interception of the data.
 The method also helps with complying with some security standards and best practices,
 such as HSTS (HTTP Strict Transport Security), which instructs browsers to always use HTTPS when
 communicating with the web application.
 */
app.UseHttpsRedirection();



/*
 
you can customize it
app.UseCors(x => x.WithOrigins(“https://example.com”).WithHeaders(“Content-Type”).WithMethods(“GET”));
 
 */

app.UseCors("MyPolicy");//Customize policy open 1,2,3 declare ConfigureService method

app.UseAuthentication();//Check JWT token

/*
 app.UseAuthorization();: This line adds the authorization middleware to your application's pipeline.

In web applications, authorization is the process of determining whether a user has the necessary
permissions to access certain resources or perform specific actions.
The UseAuthorization() method adds the authorization middleware to the request pipeline, 
allowing your application to enforce authorization rules.

By using this middleware, incoming requests will go through the authorization process, 
and if the user is not authorized to access a particular resource or perform an action,
the middleware will handle it by returning an appropriate HTTP response (usually with a status code of 403 Forbidden).

app.MapControllers();: This line configures the routing for your application's controllers.

In web applications, controllers are responsible for handling incoming requests, processing the logic,
and generating responses. The MapControllers() method configures the routing for your controllers,
meaning it maps incoming requests to the appropriate controller actions based on the specified routes.

By using this method, you enable the routing functionality for your controllers,
allowing the application to correctly route incoming requests to the corresponding controller actions 
for processing.

In summary, app.UseAuthorization() adds the authorization middleware to enforce access control
in your application, while app.MapControllers() configures the routing for your controllers,
ensuring that incoming requests are correctly mapped to the appropriate controller actions.
 */
app.UseAuthorization();

app.MapControllers();



app.Run();


