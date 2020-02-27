using System.Reflection;
using System.Web.Mvc;
using ApiBusinessMen.Services.Calculator;
using ApiBusinessMen.Services.CheckConnection;
using ApiBusinessMen.Services.Factory;
using ApiBusinessMen.Services.Persistence;
using ApiBusinessMen.Services.Repository;
using Autofac;
using Autofac.Integration.Mvc;

namespace ApiBusinessMen
{
    public class IoCConfig
    {
        public static void RegistrarControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers
                (Assembly.GetExecutingAssembly());
        }

        public static void RegistrarClases(ContainerBuilder builder)
        {
            builder.RegisterType<CheckConnection>()
                .As<ICheckConnection>().InstancePerRequest();
            builder.RegisterType<ApiJsonRepository>()
                .As<IRepository>().InstancePerRequest();
            builder.RegisterType<TransactionsBySkuFactory>()
                .As<ITransactionsBySkuFactory>().InstancePerRequest();
            builder.RegisterType<WriteJson>()
                .As<IWriteJson>().InstancePerRequest();
            builder.RegisterType<Calculator>()
                .As<ICalculator>().InstancePerRequest();
            builder.RegisterType<Algorithm>()
                .As<IAlgorithm>().InstancePerRequest();
        }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            RegistrarControllers(builder);
            RegistrarClases(builder);

            var contenedor = builder.Build();

            DependencyResolver.SetResolver
                (new AutofacDependencyResolver(contenedor));
        }
    }
}