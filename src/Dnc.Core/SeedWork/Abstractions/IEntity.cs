using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.SeedWork
{
    /// <summary>
    /// Interface for entity.
    /// </summary>
    public interface IEntity
    {
        #region Public props.
        StatusEnum Status { get; set; }

        bool CanBeRemoved { get; }

        bool CanBeSaved { get; }
        #endregion
    }
    public interface IEntity<TEntityId>
        : IEntity
    {
        TEntityId Id { get; set; }
    }
}
