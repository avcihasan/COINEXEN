using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COINEXEN.Entity
{
    public class Category
    {
        [DisplayName("Kategori İd No")]
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        //[StringLength(maximumLength:20,ErrorMessage="en fazla 20 karakter")]
        public string Name { get; set; }
        [DisplayName("Kategori Açıklaması")]
        public string Description { get; set; }

        public List<Coin> Coins { get; set; }

    }
}