using Nancy;
using $safeprojectname$.IApplication;
using $safeprojectname$.Domain.Entity;

namespace $safeprojectname$.Api.Modules
{
    /// <summary>
    /// App接口
    /// </summary>
    public class SampleModule : BaseModule
    {
        public SampleModule(IService<SampleModel,long> service) :
            base("/Sample")
        {
            Get["Default"] = _ =>
            {
                return Response.AsJson("Hello Sample!");
            };
        }
    }
}