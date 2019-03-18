using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Framework
{
    /// <summary>
    /// Framework environment.
    /// </summary>
    public class FrameworkEnvironment
    {
        #region Ctor.
        public FrameworkEnvironment()
        {
#if DEBUG
            IsDevelopment=true;
#endif
        }
        #endregion


        #region Public props.
        public bool IsDevelopment { get; set; }
        public string Environment => IsDevelopment ? "Development" : "Production"; 
        #endregion
    }
}
