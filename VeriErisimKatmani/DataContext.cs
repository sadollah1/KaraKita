using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class DataContext: DbContext
    {
        public DataContext() : base("MSSQL")
        {
            Database.SetInitializer(new DataInitilazier());
        }
        public DbSet<IletisimBilgileri> Bilgiler { get; set; }
        public DbSet<Mesaj> Mesajlar { get; set; }
        public DbSet<Kullanici> Yoneticiler { get; set; }
        public DbSet<Proje> Projeler { get; set; }
        public DbSet<Resim> Resimler { get; set; }
    }
}
