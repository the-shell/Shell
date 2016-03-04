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
    using System.Data.Entity;
    using System.Configuration;
    using Services;
    using Models;
    using Repository;
    using DAL;
    using Identity;
    using Microsoft.AspNet.Identity;
    using Ninject.Modules;
    using System.Collections.Generic;

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
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind<IDbConnectionFactory>().To<SqlConnectionFactory>()
               .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["Default"].ConnectionString);

            kernel.Bind<IUserStore<User>>().To<CustomUserStore>().InRequestScope();
            kernel.Bind<UserManager<User>>().ToSelf().InRequestScope();

            kernel.Bind<IBusinessRepository>().To<BusinessRepository>().InRequestScope();
            kernel.Bind<IBusinessService>().To<BusinessService>().InRequestScope();

            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();

            kernel.Bind<IProductRepository>().To<ProductRepository>().InRequestScope();
            kernel.Bind<IProductService>().To<ProductService>().InRequestScope();

            kernel.Bind<IImageService>().To<S3ImageService>().InRequestScope();
        }
        
    }
}