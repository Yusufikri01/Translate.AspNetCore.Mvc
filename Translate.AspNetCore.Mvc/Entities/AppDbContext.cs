using Microsoft.EntityFrameworkCore;
using Translate.AspNetCore.Mvc.Models;

namespace Translate.AspNetCore.Mvc.Entities
{
	public class AppDbContext: DbContext
	{
        public DbSet<WordModel> Words { get; set; }
        public DbSet<WordTypeModel> WordTypes { get; set; }
        public DbSet<WordLevelModel> WordLevels { get; set; }
        public DbSet<WordBookModel> WordBooks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		// VERİTABANINDA "Users" adında bir tablo oluşturuyor.
		public DbSet<UserModel> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

            modelBuilder.Entity<WordModel>()
             .HasOne(w => w.WordType)
             .WithMany(wt => wt.Words)
             .HasForeignKey(w => w.WordTypeId);

            modelBuilder.Entity<WordModel>()
                .HasOne(w => w.WordLevel)
                .WithMany(wl => wl.Words)
                .HasForeignKey(w => w.WordLevelId);

            modelBuilder.Entity<WordBookModel>()
                .HasOne(wb => wb.Word)
                .WithMany()
                .HasForeignKey(wb => wb.WordId);

            modelBuilder.Entity<WordBookModel>()
                .HasOne(wb => wb.User)
                .WithMany() // User tablosunda hangi ilişki olduğunu belirtmelisin
                .HasForeignKey(wb => wb.UserId);

            base.OnModelCreating(modelBuilder);
		}
	}
}
