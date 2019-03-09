using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelcukIeeeWebProject.Models
{
    public class EtkinlikFotografs
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Fotograf { get; set; }
        public int EtkinlikId { get; set; }

        public EtkinlikFotografs()
        {

        }

        public EtkinlikFotografs(string Ad, string Fotograf, int EtkinlikId)
        {
            this.Ad = Ad;
            this.Fotograf = Fotograf;
            this.EtkinlikId = EtkinlikId;
        }

    }
}
