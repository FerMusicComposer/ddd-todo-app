using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TasksDomain.ValueObjects
{
	public class TaskCreatedOn(DateOnly createdOn)
	{
		public DateOnly CreationDate {  get; private set; } = createdOn;

	}
}
