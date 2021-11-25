using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adify.Models;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<Adify.Models.Category> Category { get; set; }

        public DbSet<Adify.Models.Analytics> Analytics { get; set; }

        public DbSet<Adify.Models.Ad> Ad { get; set; }

        public DbSet<Adify.Models.Campaign> Campaign { get; set; }

        public DbSet<Adify.Models.Click> Click { get; set; }

        public DbSet<Adify.Models.View> View { get; set; }
    }
