using Dnc.Seedwork;

namespace Dnc.Core.Seedwork
{
    public interface IRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    { }
}
