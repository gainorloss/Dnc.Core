using Dnc.Seedwork;

namespace Dnc.Biz.Admin
{
    public class SysSetting
        : Entity
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
