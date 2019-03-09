using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelcukIeeeWebProject.Models
{
    public class Duyurulars
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Tarih { get; set; }
        public string Gonderici { get; set; }

        public Duyurulars()
        {

        }

        public Duyurulars(string Baslik, string Icerik, string Tarih, string Gonderici)
        {
            this.Baslik = Baslik;
            this.Icerik = Icerik;
            this.Tarih = Tarih;
            this.Gonderici = Gonderici;
        }

    }
}
