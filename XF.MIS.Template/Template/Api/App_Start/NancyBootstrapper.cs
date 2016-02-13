using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using Autofac;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Json;
using Nancy.TinyIoc;

namespace $safeprojectname$.Api
{
    public class NancyBootstrapper : AutofacNancyBootstrapper
    {
        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during application startup.

            //            pipelines.RegisterCompressionCheck();
            //            pipelines.AfterRequest += (ctx) =>
            //            {
            //                //                    if (ctx.Response.ContentType == "text/html")
            //                //                    ctx.Response.ContentType = ctx.Response.ContentType + "; charset=utf-8";
            //
            //                //                    var response = ctx.Response;
            //                //                    var contents = response.Contents;
            //                //                    response.Contents = responseStream =>
            //                //                        {
            //                //                            using (var stream = new StreamWriter(responseStream, Encoding.UTF8))
            //                //                            {
            //                //                                contents(stream.BaseStream);
            //                //                            }
            //                //                            //                            var stream = new StreamReader(responseStream, Encoding.UTF8);
            //                //                        };
            //
            //                //                    var jsonBytes = Encoding.UTF8.GetBytes();
            //                //                    return new Response
            //                //                    {
            //                //                        ContentType = "application/json",
            //                //                        Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
            //                //                    };
            //            };

            //显示详细错误
            StaticConfiguration.DisableErrorTraces = false;
            //设置Json字符串最大长度
            JsonSettings.MaxJsonLength = int.MaxValue;

            base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            var builder = new ContainerBuilder();

            //获取引用的程序集
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();

            //装载仓储
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();

            //装载服务
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            //            builder.RegisterType<User>()
            //                   .As<IUser>()
            //                   .SingleInstance();

            builder.Update(existingContainer.ComponentRegistry);
        }

        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            // Perform registrations that should have a request lifetime
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during request startup.
        }
    }
}