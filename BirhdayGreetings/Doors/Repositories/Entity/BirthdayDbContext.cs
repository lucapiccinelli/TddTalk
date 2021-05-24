using System;
using System.Collections.Generic;
using System.Text;
using BirthdayGreetings.Doors.Repositories.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BirthdayGreetings.Doors.Repositories.Entity
{
    class BirthdayDbContext : DbContext
    {
        public DbSet<BirthdayMessageEntity> BirthdayMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
