/********************************************
  IRepository:仓储接口

  Creator:gainorloss 创建时间:2019-06-27
  Copyright (c) gainorloss Std.
*********************************************/

using Dnc.Seedwork.Abstractions;
using System;
using System.Threading.Tasks;

namespace Dnc.Seedwork
{
    public interface IRepository<TDomainObject,TIdentity> : IUnitOfWork,IDisposable
    {
        long NextIdentity();

        Task Add(params TDomainObject[] domainObjects);

        Task Remove(params TDomainObject[] domainObjects);

        TDomainObject OfId(TIdentity key);
    }
}
