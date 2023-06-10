//using COINEXEN.Tasks.Jobs;
//using Quartz;
//using Quartz.Impl;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace COINEXEN.Tasks.Triggers
//{
//    public class DegerTrigger
//    {
//        public static void Baslat()
//        {
//            IScheduler zamanlayici = StdSchedulerFactory.GetDefaultScheduler();

//            if (!zamanlayici.IsStarted)
//            {
//                zamanlayici.Start();
//            }

//            IJobDetail gorev = JobBuilder.Create<DegerJob>().Build();


//            ICronTrigger tetikleyici = (ICronTrigger)TriggerBuilder.Create()
//                .WithIdentity("DegerJob", "null")
//                .WithCronSchedule("0/1 * * * * ?")
//                .Build();


//            zamanlayici.ScheduleJob(gorev, tetikleyici);
//        }
//    }
//}