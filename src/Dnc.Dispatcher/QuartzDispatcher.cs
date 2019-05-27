using Dnc.Serializers;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Dispatcher
{
    /// <summary>
    /// The center to manage schedule.
    /// </summary>
    public class QuartzDispatcher : IDispatcher
    {
        #region Private Members.
        private static IScheduler _scheduler;
        private static List<Schedule> _schedules = new List<Schedule>();
        #endregion 

        #region Static ctor.
        static QuartzDispatcher()
        {
            if (_scheduler == null)
            {
                var properties = new NameValueCollection();
                var schedulerFactory = new StdSchedulerFactory(properties);

                _scheduler = schedulerFactory.GetScheduler().Result;
            }
        }
        #endregion

        #region Public methods.
        public async Task StartAsync(string name = "default", string groupName = "default")
        {
            //get scheduler from scheduler factory.
            await _scheduler.Start();

            var schedule = _schedules.SingleOrDefault(s => s.GroupName.Equals(groupName) && s.Name.Equals(name));

            if (schedule == null)
            {
                throw new NullReferenceException($"Not exsited this schedule {groupName}-{name} in current schedule list.");
            }

            var assembly = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, schedule.AssemblyName));
            var job = assembly.CreateInstance(schedule.TypeName);

            var key = $"{schedule.GroupName}-{schedule.Name}";

            var data = new Dictionary<string, object>
            {
                { "name", $"{schedule.GroupName}-{schedule.Name}" }
            };

            var jobDetail = JobBuilder.Create(job.GetType())
                .WithIdentity(key)
                .Build();
            jobDetail.JobDataMap.PutAll(data);

            var schedueBuiler = CronScheduleBuilder.CronSchedule(schedule.CronExpression);

            var trigger = TriggerBuilder.Create()
                .StartNow()
                .WithIdentity(key)
                .WithSchedule(schedueBuiler)
                .ForJob(jobDetail)
                .Build();

            await _scheduler.ScheduleJob(jobDetail, trigger);
        }

        public async Task RegisterAndStartAsync(string name, string cronExpression, string typeName, string assemblyName, string groupName = "default")
        {
            _schedules.Add(new Schedule(name, typeName, cronExpression, assemblyName, groupName));

            await StartAsync(name, groupName);
        }

        public async Task ShutdownAsync()
        {
            if (_scheduler != null)
                await _scheduler.Shutdown();
        }
        #endregion
    }
}
