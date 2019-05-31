using System;

namespace Dnc.Seedwork
{
    public interface IAuditBehavior
    {
        bool Audited { get; set; }
        DateTime AuditedAt { get; set; }
        long AuditorId { get; set; }
        string Auditor { get; set; }
    }
}
