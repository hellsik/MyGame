using MyGame.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MyGame.DAL
{
    public class MyGameContext : DbContext
    {
        public MyGameContext() : base("DefaultConnection")
        {
        }

        public DbSet<Hero> Heros { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}