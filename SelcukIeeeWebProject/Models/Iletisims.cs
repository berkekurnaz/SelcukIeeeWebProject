using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelcukIeeeWebProject.Models
{
    public class Iletisims
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Baslik { get; set; }
        public string Mesaj { get; set; }
        public string Tarih { get; set; }
        public string Durum { get; set; }

        public Iletisims()
        {

        }

        public Iletisims(string AdSoyad, string Mail, string Telefon, string Baslik, string Mesaj, string Tarih, string Durum)
        {
            this.AdSoyad = AdSoyad;
            this.Mail = Mail;
            this.Telefon = Telefon;
            this.Baslik = Baslik;
            this.Mesaj = Mesaj;
            this.Tarih = Tarih;
            this.Durum = Durum;
        }

    }
}
