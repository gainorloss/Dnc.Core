using System;

namespace Dnc.Seedwork
{
    public abstract class Entity
        : IEntity<long>
    {
        #region Public props.
        public StatusEnum Status { get; set; }

        public bool CanBeRemoved => ValidateBeforeRemoved();

        public bool CanBeSaved => ValidateBeforeSaved();

        public long Id { get; set; }
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
