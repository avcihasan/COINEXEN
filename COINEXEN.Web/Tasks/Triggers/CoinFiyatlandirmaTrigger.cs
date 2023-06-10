//using COINEXEN.Tasks.Jobs;
//using Quartz;
//using Quartz.Impl;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace COINEXEN.Tasks.Triggers
//{
//    public class CoinFiyatlandirmaTrigger
//    {
//        public static void Baslat()
//        {
//            IScheduler zamanlayici = StdSchedulerFactory.GetDefaultScheduler();

//            if (!zamanlayici.IsStarted)
//            {
//                zamanlayici.Start();
//            }

//            IJobDetail gorev = JobBuilder.Create<CoinFiyatlandirmaJob>().Build();


//            ICronTrigger tetikleyici = (ICronTrigger)TriggerBuilder.Create()
//                .WithIdentity("CoinFiyatlandirmaJob", "null")
//                .WithCronSchedule("0 0/9 * * * ?")
//                .Build();


//            zamanlayici.ScheduleJob(gorev, tetikleyici);
//        }
//    }
//}