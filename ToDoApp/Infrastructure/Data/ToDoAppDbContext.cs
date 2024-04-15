using Microsoft.EntityFrameworkCore;
using Domain.ToDo.Entities;

namespace Infrastructure.Data
{
	public class ToDoAppDbContext: DbContext
	{
		public DbSet<Todo> Todos { get; set; }

		public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options) { }

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
