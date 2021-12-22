using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdifyCMS.Models;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<AdifyCMS.Models.Campaign> Campaign { get; set; }

        public DbSet<AdifyCMS.Models.Ad> Ad { get; set; }

        public DbSet<AdifyCMS.Models.Analytics> Analytics { get; set; }

        public DbSet<AdifyCMS.Models.View> View { get; set; }

        public DbSet<AdifyCMS.Models.Click> Click { get; set; }

        public DbSet<AdifyCMS.Models.User> User { get; set; }
}
