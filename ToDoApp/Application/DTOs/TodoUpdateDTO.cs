using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;

public class TodoUpdateDTO
{
	[Required]
	public string? Title { get; set; }
	[Required] 
	public string? Description { get; set; }

	public bool IsCompleted { get; set; }
}
																									