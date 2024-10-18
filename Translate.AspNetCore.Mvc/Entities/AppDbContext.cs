using Microsoft.EntityFrameworkCore;
using Translate.AspNetCore.Mvc.Models;

namespace Translate.AspNetCore.Mvc.Entities
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<UserViewModel> UserViewModel { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
