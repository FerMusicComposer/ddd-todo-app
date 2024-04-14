using Microsoft.EntityFrameworkCore;
using Domain.ToDo.Entities;

namespace Infrastructure.Data
{
	public class ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : DbContext(options)
	{
		public DbSet<Todo> Todos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Todo>(entity =>
			{
				entity.Property(e => e.Id).ValueGeneratedOnAdd();
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Title).IsRequired();
				entity.OwnsOne(e => e.CreatedOn);
				entity.ToTable("Todos");
			});
		}
	}
}
