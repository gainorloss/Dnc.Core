/************************************************************************
            IClone.cs:可复制的

            创建人：gainorloss 创建时间：【2019-07-24】
            Copyright (C) gainorloss private.
 *************************************************************************/
using System;
namespace Dnc.Seedwork
{

    /// <summary>
    /// 表示对象可以被复制,类似于<see cref="ICloneable"/>
    /// </summary>
    public interface IClone : ICloneable
    {
        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns>object</returns>
        object DeepClone();

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns>object</returns>
        object ShallowClone();
    }
}
