[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Shell.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Shell.App_Start.NinjectWebCommon), "Stop")]

namespace Shell.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Reflection;
    using Models.Repository;
    using Models.Services;
    using DAL;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Configuration;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();

            kernel.Bind<IOrganisationService>().To<OrganisationService>().InRequestScope();
            kernel.Bind<IRepository<Organisation>>().To<SqlOrganisationRepository>().InRequestScope();

            kernel.Bind<IProductService>().To<ProductService>().InRequestScope();
            kernel.Bind<IRepository<Product>>().To<SqlProductRepository>().InRequestScope();

            kernel.Bind<IUserStore<ApplicationUser>>()
                .To<UserStore<ApplicationUser>>()
                .WithConstructorArgument("context", context => kernel.Get<ApplicationDbContext>());

            kernel.Bind<IAuthenticationManager>().ToMethod(
                c =>
                    HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            
        }
        
    }
}
