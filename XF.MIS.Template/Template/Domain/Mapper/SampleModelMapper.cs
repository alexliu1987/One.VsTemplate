using DapperExtensions.Mapper;
using $safeprojectname$.Domain.Entity;

namespace $safeprojectname$.Domain.Mapper
{
    public sealed class SampleModelMapper : ClassMapper<SampleModel>
    {
        public SampleModelMapper()
        {
            Table("Xf_Sample");
            AutoMap();
        }
    }
}
