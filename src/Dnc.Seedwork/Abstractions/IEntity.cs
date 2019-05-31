using System;

namespace Dnc.Seedwork
{
    /// <summary>
    /// Interface for entity.
    /// </summary>
    public interface IEntity
    {
        DateTime CreatedAt { get; set; }
        string Creator { get; set; }
    }
}
