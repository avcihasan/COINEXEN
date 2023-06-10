//using COINEXEN.Entity;
//using COINEXEN.Identity;
//using Quartz;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace COINEXEN.Tasks.Jobs
//{
//    public class DegerJob : IJob
//    {
//        DataContext _context;
//        IdentityDataContext _icontext;
//        public DegerJob()
//        {
//            _context = new DataContext();
//            _icontext = new IdentityDataContext();
//        }

//        public void Execute(IJobExecutionContext context)
//        {
//            try
//            {
//                hesapdeger();
//                _icontext.SaveChanges();
//            }
//            catch
//            {


//            }
//        }

//        void hesapdeger()
//        {
            
//            var users = _icontext.Users.ToList();
//            foreach (var item in users)
//            {
//                var orderss = _context.OrderLines.Where(i=>i.Username==item.UserName).ToList();
//                item.HesapDeger = 0;
//                foreach (var item0 in orderss)
//                {
//                    item.HesapDeger = item.HesapDeger + (item0.Coin.Price*item0.Quantity);
//                }
//            }

//        }

//    }
//}