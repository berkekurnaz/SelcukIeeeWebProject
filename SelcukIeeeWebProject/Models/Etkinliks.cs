using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelcukIeeeWebProject.Models
{
    public class Etkinliks
    {
        public int Id { get; set; }
        public string EtkinlikAd { get; set; }
        public string EtkinlikAciklama { get; set; }
        public string Tarih { get; set; }

        public Etkinliks()
        {

        }

        public Etkinliks(string EtkinlikAd, string EtkinlikAciklama, string Tarih)
        {
            this.EtkinlikAd = EtkinlikAd;
            this.EtkinlikAciklama = EtkinlikAciklama;
            this.Tarih = Tarih;
        }

    }
}
