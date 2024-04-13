using Microsoft.EntityFrameworkCore;
using Domain.ToDo.Entities;

namespace Infrastructure.Data
{
	public class ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : DbContext(options)
	{
		public DbSet<Todo> Todos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Todo>().OwnsOne(p => p.CreatedOn);
			modelBuilder.Entity<Todo>().ToTable("ToDos");
			modelBuilder.Entity<Todo>().HasKey(t => t.Id);
			modelBuilder.Entity<Todo>().Property(t => t.Title).IsRequired();
		}
	}
}
