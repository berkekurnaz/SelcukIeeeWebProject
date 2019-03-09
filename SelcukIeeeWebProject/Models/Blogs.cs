using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelcukIeeeWebProject.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Yazar { get; set; }
        public string EklenmeTarihi { get; set; }
        public string Fotograf { get; set; }

        public Blogs()
        {

        }

        public Blogs(string Baslik, string Icerik, string Yazar, string EklenmeTarihi, string Fotograf)
        {
            this.Baslik = Baslik;
            this.Icerik = Icerik;
            this.Yazar = Yazar;
            this.EklenmeTarihi = EklenmeTarihi;
            this.Fotograf = Fotograf;
        }

    }
}
