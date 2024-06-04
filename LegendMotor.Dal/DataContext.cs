using LegendMotor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendMotor.Dal
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=legendmotor;Uid=root;Pwd=pass1234;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinLocationStaff>()
                .HasKey(m => new { m.BinLocationCode, m.StaffId, });
        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<BinLocation> BinLocation { get; set; }
        public DbSet<BinLocationStaff> BinLocationStaff { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<BinLocationSpare> BinLocationSpare { get; set; }
        public DbSet<Spare> Spare { get; set; }
    }
}
