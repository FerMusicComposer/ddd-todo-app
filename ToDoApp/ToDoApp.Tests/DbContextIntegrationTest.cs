using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Tests;

public class DbContextIntegrationTest
{
	

	[Fact]
	public void CanConnectToDatabase()
	{
		//Arrange
		string serverName = Environment.MachineName;
		string connectionString = "Data Source={ServerName};Integrated Security=True;Trust Server Certificate=True";
		string cs = connectionString.Replace("{ServerName}", serverName);

		var options = new DbContextOptionsBuilder<ToDoAppDbContext>()
			.UseSqlServer(cs)
			.Options;

		//Act & Assert
		using (var context = new ToDoAppDbContext(options))
		{
			Assert.True(context.Database.CanConnect());
		}
	}
}
