using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BankDB
{
    /// <summary>
    /// Application context class for using DB
    /// </summary>
    public class ApplicationContext : DbContext
    {

        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Construct of ApplicationContext. Create new or make sure exists DB.
        /// </summary>
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Make connection to DB
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bankappdb;Trusted_Connection=True;");
        }
    }
}

