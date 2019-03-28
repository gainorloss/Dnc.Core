namespace Dnc
{
    /// <summary>
    /// Default framework construction.
    /// </summary>
    public class DefaultFrameworkConstruction
        : FrameworkConstruction
    {
        #region Default ctor.
        public DefaultFrameworkConstruction()
        {
            this.Configure()
                .UseDefaultLogger()
                .UseDefaultSerializer();//use json-net serializer.
        } 
        #endregion
    }
}
