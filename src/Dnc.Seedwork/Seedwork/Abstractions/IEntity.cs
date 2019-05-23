using System;

namespace Dnc.Seedwork
{
    /// <summary>
    /// Interface for entity.
    /// </summary>
    public interface IEntity
    {
        DateTime CreateTime { get; set; }
        string CreateRemark { get; set; }
    }
}
