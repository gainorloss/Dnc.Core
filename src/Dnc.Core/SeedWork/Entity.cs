using System;

namespace Dnc.SeedWork
{
    public abstract class Entity
        : IEntity
    {
        #region Public props.
        public StatusEnum Status { get; set; }

        public bool CanBeRemoved => ValidateBeforeRemoved();

        public bool CanBeSaved => ValidateBeforeSaved();
        #endregion

        #region Virtual methods.
        public virtual bool ValidateBeforeSaved()
        {
            if (Status == StatusEnum.Created || Status == StatusEnum.Removed)
            {
                return IsPrimaryKeyNone();
            }
            return !IsPrimaryKeyNone();
        }

        public virtual bool ValidateBeforeRemoved() => !IsPrimaryKeyNone();

        public virtual void GeneratePrimaryKey()
        { }

        public virtual bool IsPrimaryKeyNone() => true;
        #endregion
    }
}
