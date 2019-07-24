using System;

namespace Dnc.Seedwork
{
    /// <summary>
    /// Interface for entity.
    /// </summary>
    public interface IEntity:IClone
    {
        DateTime CreatedAt { get; set; }
        string Creator { get; set; }
    }
}
