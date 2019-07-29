/********************************************
  RepositoryBase<TDomainObject, TKey>:仓储抽象基类

  Creator:gainorloss 创建时间:2019-06-27
  Copyright (c) gainorloss Std.
*********************************************/

using Dnc.ObjectId;
using System;
using System.Threading.Tasks;

namespace Dnc.Seedwork
{
    public abstract class RepositoryBase<TDomainObject, TIdentity>
        : IRepository<TDomainObject, TIdentity>
    {
        private readonly IObjectIdGenerator _objectIdGenerator;
        public RepositoryBase()
        {
            _objectIdGenerator = Fx.Resolve<IObjectIdGenerator>();
        }

        public long NextIdentity() => _objectIdGenerator.IntSnowflakeId();

        public abstract Task CreateAsync(params TDomainObject[] domainObjects);

        public abstract TDomainObject OfId(TIdentity key);

        public abstract Task Remove(params TDomainObject[] domainObjects);

        public abstract int Save();

        public virtual async Task<int> SaveAsync() => await Task.Run(() => Save());

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~RepositoryBase() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
