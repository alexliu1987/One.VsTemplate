using System.Web;
using Nancy;

namespace $safeprojectname$.Api
{
    public class BaseModule : NancyModule
    {
        public BaseModule(string detachmentunit)
            : base(detachmentunit)
        {
        }

        public BaseModule()
        {

        }
    }
}