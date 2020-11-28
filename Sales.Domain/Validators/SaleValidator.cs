using Sales.Domain.Entities;
using Sales.Domain.Validators.Contracts;
using Sales.Resources;
using System.Linq;

namespace Sales.Domain.Validators
{
	public class SaleValidator : IValidator<Sale>
	{
		public bool Validate(Sale entity, out ValidationResult validationResult)
		{
			validationResult = new ValidationResult();

			if (!entity.Items.Any())
				validationResult.AddValidationMessage(Resource.ASaleMustHaveAtLeastOneItem);

			return validationResult.IsValid;
		}
	}
}
