using LegendMotor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;

namespace LegendMotor.Dal
{
    public class DataContext : DbContext
    {
        public readonly ILoggerFactory MyLoggerFactory;

        public DataContext()
        {
            MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("Server=localhost;Database=legendmotor;Uid=root;Pwd=pass1234;");

            //you will not be able to open the sqlite database file if you put it in C drive, windows will not permit you to read/write the db file
            DirectoryInfo soultion = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent;
            string path = soultion.ToString();
            string sqliteDb = Path.Combine(path, "LegendMotor.Dal", "legendmotor.db");
            string db = "Data Source=file:" + sqliteDb + ";Mode=ReadWrite;";
            optionsBuilder.UseSqlite(db);
            optionsBuilder.LogTo(Console.WriteLine);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composite primary key
            modelBuilder.Entity<BinLocationStaff>()
                .HasKey(m => new { m.BinLocationCode, m.StaffId, });

            modelBuilder.Entity<Staff>()
                .HasIndex(staff => new {staff.Email, staff.Name})
                .IsUnique();

            modelBuilder.Entity<SparePrice>()
                .HasKey(m => new { m.SpareID, m.SupplierCode });
        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<BinLocation> BinLocation { get; set; }
        public DbSet<BinLocationStaff> BinLocationStaff { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<BinLocationSpare> BinLocationSpare { get; set; }
        public DbSet<Spare> Spare { get; set; }
        public DbSet<Dealer> Dealer { get; set; }
        public DbSet<IncomingOrder> IncomingOrder { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<SparePrice> SparePrice { get; set; }

        public DbSet<Supplier> Supplier { get; set; }
    }
}
