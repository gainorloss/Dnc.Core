using Dnc.Dispatcher;
using Dnc.Framework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Framework
{
    public class FrameworkConstruction
    {
        #region Public memebers.
        public IServiceCollection Services { get; set; }
        public IConfiguration Configuration { get; set; }
        public FrameworkEnvironment Environment { get; set; }

        public ScheduleCenter ScheduleCenter { get; set; }

        #endregion

        #region Default ctor.
        public FrameworkConstruction()
        {
            Services = new ServiceCollection();

            Environment = new FrameworkEnvironment();
            Services.AddSingleton(Environment);
        }
        #endregion
    }
}
