using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
	public class TodoCreateDTO
	{
		[Required]
		[StringLength(100, MinimumLength = 5)]
		public string? Title { get; set; }

		[StringLength(500)]
		public string? Description { get; set; }
	}
}
