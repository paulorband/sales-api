using System;

namespace Domain
{
	public class EntityValidationException : Exception
	{
		public EntityValidationException(string message) : base(message)
		{
		}
	}
}
