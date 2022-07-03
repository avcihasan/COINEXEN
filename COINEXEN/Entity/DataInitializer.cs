using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace COINEXEN.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            var kategoriler = new List<Category>()
            {
                new Category(){Name="Sanat",Description="kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"},
                new Category(){Name="Spor",Description="aaaaaaaaaaaaaaaaaaaaaaaaaaaaa"},
                new Category(){Name="Teknoloji",Description="kkkkkkkkkkkkkkasskkkkkkkkkkkkkkkkkkkkkk"},
                new Category(){Name="Bilim",Description="sss"},
                new Category(){Name="Ticaret",Description="kkkkkkkkkkkkkkkkkkksskkkkkkkkkkkkkkkkk"},
                new Category(){Name="Müzik",Description="kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"},
                new Category(){Name="Seyehat",Description="kkkkkkkkkkkkkkkkssskkkkkkkkkkkkkkkkkkkk"},
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var coinler = new List<Coin>()
            {
                new Coin(){Name="Acoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.2, KısaKod="A",CategoryId=1,OldPrice=0 },
                new Coin(){Name="Bcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.9, KısaKod="B",CategoryId=2,OldPrice=0 },
                new Coin(){Name="Ccoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=2.4, KısaKod="C",CategoryId=3 ,OldPrice=0},
                new Coin(){Name="Dcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=5.4, KısaKod="D",CategoryId=1 ,OldPrice=0},
                new Coin(){Name="Ecoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=15.4, KısaKod="E",CategoryId=5 ,OldPrice=0},
                new Coin(){Name="Fcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=6.4, KısaKod="F",CategoryId=6 ,OldPrice=0},
                new Coin(){Name="Gcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.43, KısaKod="G",CategoryId=2 ,OldPrice=0},
                new Coin(){Name="Hcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.55, KısaKod="H",CategoryId=1 ,OldPrice=0},
                new Coin(){Name="Icoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.98, KısaKod="I",CategoryId=6 ,OldPrice=0},
                new Coin(){Name="Jcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=11.24, KısaKod="J",CategoryId=1 ,OldPrice=0},
                new Coin(){Name="Kcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.24, KısaKod="K",CategoryId=2 ,OldPrice=0},
                new Coin(){Name="Lcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=12.4, KısaKod="L",CategoryId=5 ,OldPrice=0},
                new Coin(){Name="Mcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=31.4, KısaKod="M",CategoryId=5 ,OldPrice=0},
                new Coin(){Name="Ncoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=16.4, KısaKod="N",CategoryId=2 ,OldPrice=0},
                new Coin(){Name="Ocoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.94, KısaKod="O",CategoryId=3 ,OldPrice=0},
                new Coin(){Name="Pcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.49, KısaKod="P",CategoryId=3,OldPrice=0},
                new Coin(){Name="Rcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.4, KısaKod="R",CategoryId=4 ,OldPrice=0},
                new Coin(){Name="Scoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=31.4, KısaKod="S",CategoryId=3 ,OldPrice=0},
                new Coin(){Name="Tcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=13.43, KısaKod="T",CategoryId=1 ,OldPrice=0},
                new Coin(){Name="Ucoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=15.4, KısaKod="U",CategoryId=1 ,OldPrice=0},
                new Coin(){Name="Vcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.44, KısaKod="V",CategoryId=6,OldPrice=0},
                new Coin(){Name="Ycoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.4, KısaKod="Y",CategoryId=5,OldPrice=0},
                new Coin(){Name="Zcoin",Photo="1.jpg",Description="Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium?",Stock=10000000,Price=1.4, KısaKod="Z",CategoryId=4 ,OldPrice=0},
              

            };

            foreach (var coin in coinler)
            {
                context.Coin.Add(coin);
            }
            context.SaveChanges();

            base.Seed(context); 
        }
    }
}