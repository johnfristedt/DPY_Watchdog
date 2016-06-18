using DPY2.WebAdmin.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DPY2.WebAdmin.EntityFramework.Contexts
{
    public class DpyContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        public DbSet<Block> Blocks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Skill> Skills { get; set; }
    }
}