using System.Web.Http;
using System.Reflection;
using Microsoft.Owin;
using Owin;

using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

using BullsAndCows.Data;
using BullsAndCows.WebApi.Infrastructure;

[assembly: OwinStartup(typeof(BullsAndCows.WebApi.Startup))]

namespace BullsAndCows.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IGameData>().To<GameData>()
                .WithConstructorArgument("context", c => new GameDbContext());

            kernel.Bind<IUserIdProvider>().To<AspNetUserIdProvider>();
            kernel.Bind<IGameLogic>().To<GameLogic>();
        }
    }
}
