using Dnc.FaultToleranceProcessors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc
{
    public static class FaultToleranceProcessorExtensions
    {
        /// <summary>
        /// Gets it from a <see cref="IFaultToleranceProcessor"/>.
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction UseFaultToleranceProcessor(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IFaultToleranceProcessor,PollyFaultToleranceProcessor>();
            return construction;
        }
    }
}
