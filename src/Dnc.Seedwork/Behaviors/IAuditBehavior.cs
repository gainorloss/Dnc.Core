namespace Dnc.Seedwork
{
    public interface IAuditBehavior
    {
        bool Audited { get; set; }
        string AuditRemark { get; set; }
    }
}
