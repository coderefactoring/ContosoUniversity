using AutoMapper;
using AutoMapper.Configuration;
using ContosoUniversity.Mapper;
using Unity;
using Unity.Injection;

namespace ContosoUniversity
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings(IUnityContainer container)
        {
            var mce = new MapperConfigurationExpression();
            mce.AddProfile<EnrollmentDateGroupProfile>();
            mce.AddProfile<StudentProfile>();

            var mc = new MapperConfiguration(mce);
            mc.AssertConfigurationIsValid();

            container.RegisterSingleton<IMapper, AutoMapper.Mapper>(
                new InjectionConstructor(mc));
        }
    }
}