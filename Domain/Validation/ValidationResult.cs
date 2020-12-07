using System.Collections.Generic;
using System.Linq;

namespace Domain.Validation
{
	public class ValidationResult
	{
		public bool IsValid => !ValidationMessage.Any();
		public IList<string> ValidationMessage { get; set; } = new List<string>();

		public void AddValidationMessage(string message) => ValidationMessage.Add(message);

		public string JoinMessages(string separator = " | ")
		{
			if (IsValid)
				return string.Empty;

			return string.Join(separator, ValidationMessage);
		}
	}
}
