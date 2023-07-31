using AtikYonetim.Core.Entities;
using AtikYonetim.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AtikYonetim.Models.Data.Context
{
    public class WasteDbContext : DbContext
    {

        public WasteDbContext(DbContextOptions<WasteDbContext> options) : base(options)
        {

        }

        public DbSet<WasteOperationVM> sp_WasteOperation { get; set; }
        public DbSet<WasteOperationVM> sp_WasteOperationDetail { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WasteOperation>().ToTable("tbl_WasteOperation").HasKey(m => m.ID);
            builder.Entity<Store>().ToTable("tbl_Stores").HasKey(m => m.ID);
            builder.Entity<Company>().ToTable("tbl_Companies").HasKey(m => m.ID);
            builder.Entity<Definition>().ToTable("tbl_Definition").HasKey(m => m.ID);

            base.OnModelCreating(builder);
        }
    }

}