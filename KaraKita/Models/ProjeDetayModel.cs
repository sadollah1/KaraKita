using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraKita.Models
{
    public class ProjeDetayModel
    {
        public VeriErisimKatmani.Proje Proje { get; set; }
        public List<VeriErisimKatmani.Proje> Projeler { get; set; }
    }
}