using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COINEXEN.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string KullaniciAdi { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public string Eposta { get; set; }
        public KonuBaslik KonuBaslik { get; set; }
        public string Detay { get; set; }
        public DateTime GonderimTarihi { get; set; }

    }
    public enum City
    {
                         Adana
                        ,Adıyama
                        ,Afyonkarahisar
                        ,Ağrı
                        ,Amasya,
                        Ankara,
                        Antalya,
                        Artvin,
                        Aydın,
                        Balıkesir,
                        Bilecik,
                        Bingöl,
                        Bitlis,
                        Bolu,
                        Burdur,
                        Bursa,
                        Çanakkale,
                        Çankırı,
                        Çorum,
                        Denizli,
                        Diyarbakır,
                        Edirne,
                        Elazığ,
                        Erzincan,
                        Erzurum,
                        Eskişehir,
                        Gaziantep,
                        Giresun,
                        Gümüşhane,
                        Hakkâri,
                        Hatay,
                        Isparta,
                        Mersin,
                        İstanbul,
                        İzmir,
                        Kars,
                       Kastamonu,
                       Kayseri,
                        Kırklareli,
                        Kırşehir,
                        Kocaeli,
                        Konya,
                        Kütahya,
                        Malatya,
                        Manisa,
                        Kahramanmaraş,
                        Mardin,
                       Muğla,
                        Muş,
                        Nevşehir,
                        Niğde,
                        Ordu,
                        Rize,
                        Sakarya,
                        Samsun,
                       Siirt,
                        Sinop,
                        Sivas,
                        Tekirdağ,
                        Tokat,
                        Trabzon,
                        Tunceli,
                        Şanlıurfa,
                        Uşak,
                        Van,
                        Yozgat,
                        Zonguldak,
                       Aksaray,
                        Bayburt,
                        Karaman,
                        Kırıkkale,
                        Batman,
                       Şırnak,
                        Bartın,
                        Ardahan,
                       Iğdır,
                        Yalova,
                        Karabük,
                        Kilis,
                        Osmaniye,
                        Düzce
    }
    public enum KonuBaslik
    {
        Baslik1,
        Baslik2,
        Baslik3,
        Baslik4,
        Baslik5,
        Baslik6,

    }


}