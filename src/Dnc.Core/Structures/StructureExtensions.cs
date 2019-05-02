using Microsoft.Extensions.DependencyInjection;

namespace Dnc.Structures
{
    public static class StructureExtensions
    {
        public static FrameworkConstruction UseQueue(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IQueue, IOQueue>();
            return construction;
        }
    }
}
