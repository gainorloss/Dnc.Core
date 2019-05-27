using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc.Dispatcher
{
    /// <summary>
    /// Job.
    /// </summary>
    public class Dispatch
    {
        #region Default ctor.
        public Schedule()
        { }
        #endregion

        #region Ctor.
        public Schedule(string name,
           string typeName,
           string cronExpression,
           string assemblyName,
           string groupName)
           : this()
        {
            Name = name;
            TypeName = typeName;
            CronExpression = cronExpression;
            AssemblyName = assemblyName;
            GroupName = groupName;
        }
        #endregion

        #region Public members.
        /// <summary>
        /// Job name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Job group name.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Job description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The url for this job requesting. 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Begin time.
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// End time.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Cron expression.
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        /// The description for the cron expression.
        /// </summary>
        public string CronDescription { get; set; }

        /// <summary>
        /// The name of this assembly which defined the job.
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// The name of this type which defined the job.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Schedule status <see cref="DispatchStatus"/>;
        /// </summary>
        public DispatchStatus Status { get; set; } 
        #endregion
    }
}
