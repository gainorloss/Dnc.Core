/********************************************
  IRepository:仓储接口

  Creator:gainorloss 创建时间:2019-06-27
  Copyright (c) gainorloss Std.
*********************************************/

using Dnc.Seedwork.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dnc.Seedwork
{
    public interface IRepository<TDomainObject, TIdentity> : IUnitOfWork, IDisposable
    {
        long NextIdentity();

        /// <summary>
        /// 单个添加
        /// </summary>
        /// <param name="domainObjects"></param>
        /// <returns></returns>
        Task CreateAsync(params TDomainObject[] domainObjects);

        #region Sparkles:bulk:10~3000，batch:>3000 gainorloss【2019-07-29】
        /// <summary>
        /// 操作在3000条以内
        /// </summary>
        /// <param name="domainObjects"></param>
        /// <returns></returns>
        Task BulkCreateAsync(IList<TDomainObject> domainObjects);

        /// <summary>
        /// 批量操作:3000条以上
        /// </summary>
        /// <param name="domainObjects"></param>
        /// <returns></returns>
        Task BatchCreateAsync(IList<TDomainObject> domainObjects);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task BatchUpdateAsync(Expression<Func<TDomainObject, bool>> where);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task BatchDeleteAsync(Expression<Func<TDomainObject, bool>> where);
        #endregion

        Task Remove(params TDomainObject[] domainObjects);

        TDomainObject OfId(TIdentity key);
    }
}
