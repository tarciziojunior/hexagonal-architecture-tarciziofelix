namespace Tarcizio.Infrastructure.Integrations
{
    using Autofac;
    using System.Net.Http;

    public class Module : Autofac.Module
    {
        public string viaCep { get; set; }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new HttpClient()).As<HttpClient>().SingleInstance();

            //
            // Register all Types in Integrations namespace
            //
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("Integrations"))
                .AsImplementedInterfaces()
                .WithParameter("viaCep", viaCep)
                .InstancePerLifetimeScope();
        }
    }
}
