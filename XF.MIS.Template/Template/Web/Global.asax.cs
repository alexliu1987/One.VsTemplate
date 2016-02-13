using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;

namespace $safeprojectname$.Web
{
    public class MvcApplication : HttpApplication
    {

        protected void Application_Start()
        {
            //初始化AutoMapper
            AutoMapperConfig.BootStrapper();

            //Ioc容器注册
            IocConfig.RegisterDependencies();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //设置VM验证器为FluentValidation
            FluentValidationModelValidatorProvider.Configure();

            //ConfigCenter服务注册
            AppSettingWatchConfig.RegisterWatcher();
        }

        protected void Application_End()
        {
            //ConfigCenter服务销毁
            AppSettingWatchConfig.DisposeWatcher();
        }
    }
}

