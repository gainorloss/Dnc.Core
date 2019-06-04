using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
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
        public FrameworkEnvironment() =>  IsDevelopment = Assembly.GetEntryAssembly()?.GetCustomAttribute<DebuggableAttribute>()?.IsJITTrackingEnabled == true;
        #endregion
    }
}
