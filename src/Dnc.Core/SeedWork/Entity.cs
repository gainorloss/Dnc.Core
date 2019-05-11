using System;

namespace Dnc.Seedwork
{
    public abstract class Entity
        : IEntity<long>
    {
        #region Public props.
        public DataStatusEnum DataStatus { get; set; }

        public bool CanBeRemoved => ValidateBeforeRemoved();

        public bool CanBeSaved => ValidateBeforeSaved();

        public long Id { get; set; }
        #endregion

        #region Virtual methods.
        public virtual bool ValidateBeforeSaved() => DataStatus == DataStatusEnum.UnAudited;

        protected virtual bool ValidateBeforeRemoved() => !IsPrimaryKeyNone() && DataStatus != DataStatusEnum.Audited;

        protected virtual bool IsPrimaryKeyNone() => Id == 0;
        #endregion
    }
}
