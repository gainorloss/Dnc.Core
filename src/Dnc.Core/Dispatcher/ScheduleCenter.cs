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
    public class ScheduleCenter
    {
        #region Private Members.
        private static ISchedulerFactory _schedulerFactory;
        private static List<Schedule> _schedules = new List<Schedule>();
        #endregion 

        #region Static ctor.
        static ScheduleCenter()
        {
            if (_schedulerFactory == null)
            {
                var nameValues = new NameValueCollection();
                _schedulerFactory = new StdSchedulerFactory(nameValues);

                _schedules.Add(new Schedule()
                {
                    Name = "default",
                    GroupName = "default",
                    CronExpression = "* 30 11 ? * *",
                    AssemblyName = "Dnc.Core.dll",
                    TypeName = "Dnc.Dispatcher.HelloJob"
                });
            }
        }
        #endregion

        #region Public methods.
        public async Task RunScheduleAsync(string name = "default",
           string groupName = "default")
        {
            //get scheduler from scheduler factory.
            var scheduler = await _schedulerFactory.GetScheduler();
            await scheduler.Start();

            var schedule = _schedules.SingleOrDefault(s => s.GroupName.Equals(groupName) && s.Name.Equals(name));

            if (schedule == null)
            {
                throw new NullReferenceException($"Not exsited this schedule {groupName}-{name} in current schedule list.");
            }

            var assembly = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, schedule.AssemblyName));
            var job = assembly.CreateInstance(schedule.TypeName);

            var jobDetail = JobBuilder.Create(job.GetType())
                .WithIdentity($"{schedule.GroupName}-{schedule.Name}")
                .Build();

            var schedueBuiler = CronScheduleBuilder.CronSchedule(schedule.CronExpression);

            var trigger = TriggerBuilder.Create()
                .StartNow()
                .WithIdentity($"{schedule.GroupName}-{schedule.Name}")
                .WithSchedule(schedueBuiler)
                .ForJob(jobDetail)
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger);
        }


        public async Task CreateAndRunScheduleAsync(string name,
            string typeName,
            string cronExpression,
            string assemblyName,
            string groupName = "default")
        {
            _schedules.Add(new Schedule(name, typeName, cronExpression, assemblyName, groupName));

            await RunScheduleAsync(name, groupName);
        } 
        #endregion
    }
}
