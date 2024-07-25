using LocationRisk_Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationRisk_Database.Context
{
    internal class BankaContext: DbContext
    {

        public DbSet<Location_Risk_Data> SavedResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(LocationRisk_Variants.Configuration.ConnectionStrings.CS_BANKA);
        }
    }

}
