using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc
{
    /// <summary>
    /// Framework environment.
    /// </summary>
    public class FrameworkEnvironment
        :IFrameworkEnvironment
    {
        #region Public props.
        public bool IsDevelopment { get; set; }
        public string Environment => IsDevelopment ? "Development" : "Production";
        #endregion

        #region Ctor.
        public FrameworkEnvironment()
        {
#if DEBUG
            IsDevelopment=true;
#endif
        }
        #endregion
    }
}
