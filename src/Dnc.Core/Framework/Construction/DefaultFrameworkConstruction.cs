using Dnc.ObjectId;
using Dnc.Structures;

namespace Dnc
{
    /// <summary>
    /// Default framework construction,default:use logger、serializer、alarmer、mock repostory、scheduleCenter、object id generator.
    /// </summary>
    public class DefaultFrameworkConstruction
        : FrameworkConstruction
    {
        #region Default ctor.
        public DefaultFrameworkConstruction()
        {
            this.Configure()
                .UseDefaultLogger()
                .UseDefaultSerializer()//use json-net serializer.
                .UseAlarmer()//use alarmer.
                .UseMockRepository()//use mock repository.
                .UseScheduleCenter()//use scheduler.
                .UseObjectIdGenerator()
                .UseQueue();//object id generator.
        }
        #endregion
    }
}
