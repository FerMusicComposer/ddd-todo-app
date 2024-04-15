using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Infrastructure.Data
{
	public class ToDoAppDbContextFactory : IDesignTimeDbContextFactory<ToDoAppDbContext>
	{

		public ToDoAppDbContext CreateDbContext(string[] args)
		{
			var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var projectRoot = Path.GetFullPath(Path.Combine(assemblyLocation, "..", "..","..",".."));

			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(Path.Combine(projectRoot,"WebAPI"))
			.AddJsonFile("appsettings.Development.json")
			.Build();
			// Here we create the DbContextOptionsBuilder manually.        
			var builder = new DbContextOptionsBuilder<ToDoAppDbContext>();
			var serverName = Environment.MachineName;

			// Build connection string. This requires that you have a connectionstring in the appsettings.json
			var connectionString = configuration.GetConnectionString("ToDoApp").Replace("{ServerName}", serverName); ;
			builder.UseSqlServer(connectionString);
			// Create our DbContext.
			return new ToDoAppDbContext(builder.Options);
		}
	}
}
