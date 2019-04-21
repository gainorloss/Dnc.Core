namespace Dnc
{
    /// <summary>
    /// Default framework construction,default:use logger、serializer、alarmer、scheduleCenter.
    /// </summary>
    public class DefaultFrameworkConstruction
        : FrameworkConstruction
    {
        #region Default ctor.
        public DefaultFrameworkConstruction()
        {
            this.Configure()
                .UseDefaultLogger()
                .UseDefaultSerializer()
                .UseAlarmer()
                .UseScheduleCenter();//use json-net serializer.
        } 
        #endregion
    }
}
