using Autofac;
using Autofac.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Tarcizio.Domain.Enrollment;
using Tarcizio.WebApi.Filters;
using Tarcizio.WebApi.UseCases.Enrollment;

namespace Tarcizio.WebApi
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DomainExceptionFilter));
                options.Filters.Add(typeof(ValidateModelAttribute));
            });

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();

                options.IncludeXmlComments(
                    Path.ChangeExtension(
                        typeof(Startup).Assembly.Location,
                        "xml"));

                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = Configuration["App:Title"],
                    Version = Configuration["App:Version"],
                    Description = Configuration["App:Description"],
                    TermsOfService = Configuration["App:TermsOfService"]
                });

                options.CustomSchemaIds(x => x.FullName);
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ConfigurationModule(Configuration));
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseMvc();

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tarcizio Felix");
               });
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<User, UserRequest>().ReverseMap();
                CreateMap<Address, AddressRequest>().ReverseMap();

                CreateMap<UserResponse, User>().ReverseMap();
                CreateMap<AddressResponse, Address>().ReverseMap();
            }
        }

        public class AutoMapperConfig
        {
            public static IMapper Initialize()
            {
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                return mapperConfig.CreateMapper();
            }
        }
    }
}
