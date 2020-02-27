using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ExamenAlbertoMartinezCambioDivisas.Models;

namespace ExamenAlbertoMartinezCambioDivisas.DAL
{
    public class CambioDivisasContext : DbContext
    {
        public CambioDivisasContext() : base("CambioDivisasContext") { }

        public DbSet<Rates> Rates { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ExamenAlbertoMartinezCambioDivisas.Models.ViewModel.ListadoPorSkuVM> ListadoPorSkuVMs { get; set; }
    }
}