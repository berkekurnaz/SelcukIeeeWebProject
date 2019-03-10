using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelcukIeeeWebProject.Models
{
    public class ViewModels
    {
        public Etkinliks Etkinliks { get; set; }
        public IEnumerable<EtkinlikFotografs> EtkinlikFotografs { get; set; }
    }
}
