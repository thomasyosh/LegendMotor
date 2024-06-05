using LegendMotor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace LegendMotor.Dal
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("Server=localhost;Database=legendmotor;Uid=root;Pwd=pass1234;");

            //you will not be able to open the sqlite database file if you put it in C drive, windows will not permit you to read/write the db file
            var db = new SqliteConnection("Data Source=file:..\\LegendMotor.Dal\\legendmotor.db;Mode=ReadWrite;");
            optionsBuilder.UseSqlite(db);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composite primary key
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
