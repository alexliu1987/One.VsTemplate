using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using $safeprojectname$.Application;
using $safeprojectname$.IApplication;
using $safeprojectname$.Infrastructure;

namespace $safeprojectname$.Web
{
    public static class IocConfig
    {
        private static HttpConfiguration config;

        public static void RegisterDependencies()
        {
            Ioc.InitializeWith(Register, container =>
            {
                //初始化容器，设置MVC容器为Autofac
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            });
        }

        private static void Register(ContainerBuilder builder)
        {
            //获取引用的程序集
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();

            //装载仓储
            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();

            //装载服务
            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();

            //装载泛型基类
            builder.RegisterGeneric(typeof(Domain.Repositories.Repository<,>)).As(typeof(Domain.Repositories.IRepository<,>));

            builder.RegisterGeneric(typeof(Service<,>)).As(typeof(IService<,>));

            // 装载控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            config = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(config);

            #region Register modules

            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);

            #endregion

            #region Model binder providers - excluded - not sure if need

            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            //builder.RegisterModelBinderProvider();

            #endregion

            #region Inject HTTP Abstractions

            /*
                 The MVC Integration includes an Autofac module that will add HTTP request 
                 lifetime scoped registrations for the HTTP abstraction classes. The 
                 following abstract classes are included: 
                -- HttpContextBase 
                -- HttpRequestBase 
                -- HttpResponseBase 
                -- HttpServerUtilityBase 
                -- HttpSessionStateBase 
                -- HttpApplicationStateBase 
                -- HttpBrowserCapabilitiesBase 
                -- HttpCachePolicyBase 
                -- VirtualPathProvider 

                To use these abstractions add the AutofacWebTypesModule to the container 
                using the standard RegisterModule method. 
                */
            builder.RegisterModule<AutofacWebTypesModule>();

            #endregion
        }
    }
}