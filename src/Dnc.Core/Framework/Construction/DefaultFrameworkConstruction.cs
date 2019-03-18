using Dnc.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Framework
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
                .UseDefaultLogger();
        } 
        #endregion
    }
}
