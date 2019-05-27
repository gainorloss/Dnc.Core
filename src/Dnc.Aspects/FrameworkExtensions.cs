using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;

namespace Dnc
{
    public static class FrameworkExtensions
    {
        public static FrameworkConstruction AspectsBuild(this FrameworkConstruction construction, bool logStarted = true)
        {
            construction.ConfigureBuild(fxConstruction =>
            {
                fxConstruction.Services.ConfigureDynamicProxy();
                return fxConstruction.Services.BuildAspectInjectorProvider();
            }, logStarted);
            return construction;
        }
    }
}
