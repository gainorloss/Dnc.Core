/********************************************
  IUnitOfWork:工作单元

  Creator:gainorloss 创建时间:2019-06-27
  Copyright (c) gainorloss Std.
*********************************************/

using System.Threading.Tasks;

namespace Dnc.Seedwork.Abstractions
{
    public interface IUnitOfWork
    {
        int Save();
        Task<int> SaveAsync();
    }
}
