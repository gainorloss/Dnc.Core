/********************************************
  ICocurrencySafe:抗并发接口

  Creator:gainorloss 创建时间:2019-06-27
  Copyright (c) gainorloss Std.
*********************************************/

namespace Dnc.Seedwork.Abstractions
{
    public interface IConcurrencySafe
    {
        int Version { get; }
    }
}
