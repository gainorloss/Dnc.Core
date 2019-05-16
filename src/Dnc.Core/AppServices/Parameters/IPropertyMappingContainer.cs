using Dnc.Seedwork;

namespace Dnc.AppServices
{
    public interface IPropertyMappingContainer
    {
        void Register<T>() where T : IPropertyMapping,new();

        IPropertyMapping Resolve<TSource,TDestination>() where TDestination:Entity;

        bool ValidatePropertyMappingExistsFor<TSource,TDestination>(string field) where TDestination:Entity;
    }
}
