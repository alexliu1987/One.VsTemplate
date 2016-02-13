using AutoMapper;
using $safeprojectname$.Domain.Entity;
using $safeprojectname$.Web.Models;

namespace $safeprojectname$.Web
{
    public static class AutoMapperConfig
    {
        public static void BootStrapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<SampleModel, SampleViewModel>();
//            Mapper.CreateMap<AppModel, AppDto>().
//                ForMember(t => t.SB, opt => opt.MapFrom(model => model.AppName + "SB"));
//
//            Mapper.CreateMap<AppSettingModel, SettingDto>().
//                ForMember(t => t.Key, opt => opt.MapFrom(model => model.AppSettingKey)).
//                ForMember(t => t.Name, opt => opt.MapFrom(model => model.AppSettingName)).
//                ForMember(t => t.Value, opt => opt.MapFrom(model => model.AppSettingValue));
        }
    }
}
