using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace UrlShortener
{
    public class Database : DbContext
    {
        public DbSet<Url> Urls { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseSqlite("Data source=database.db");
        }

    }
}
