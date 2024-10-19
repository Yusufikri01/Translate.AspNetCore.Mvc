using Microsoft.EntityFrameworkCore;
using Translate.AspNetCore.Mvc.Models;

namespace Translate.AspNetCore.Mvc.Entities
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		// VERİTABANINDA "Users" adında bir tablo oluşturuyor.
		public DbSet<UserModel> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
