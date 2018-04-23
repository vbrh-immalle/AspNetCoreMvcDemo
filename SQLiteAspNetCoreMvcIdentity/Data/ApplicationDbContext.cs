using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SQLiteAspNetCoreMvcIdentity.Models;

namespace SQLiteAspNetCoreMvcIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<SQLiteAspNetCoreMvcIdentity.Models.Vragenlijst> Vragenlijst { get; set; }

        public DbSet<SQLiteAspNetCoreMvcIdentity.Models.Vraag> Vraag { get; set; }

        public DbSet<SQLiteAspNetCoreMvcIdentity.Models.Antwoord> Antwoord { get; set; }

        public DbSet<SQLiteAspNetCoreMvcIdentity.Models.AntwoordCommentaar> AntwoordCommentaar { get; set; }
    }
}
