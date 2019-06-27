/********************************************
  IdentifiedDomainObject:带标识符的领域对象

  Creator:gainorloss 创建时间:2019-06-27
  Copyright (c) gainorloss Std.
*********************************************/

namespace Dnc.Seedwork
{
    public class IdentifiedDomainObject<TIdentity>
        :DomainObject
    {
        public ObjectId<TIdentity> Id { get; set; }
    }
}
