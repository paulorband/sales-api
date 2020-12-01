using Domain.Entities;
using Domain.Validators.Contracts;
using Resources;
using System.Linq;

namespace Domain.Validators
{
	public class SaleValidator : IValidator<Sale>
	{
		public bool Validate(Sale entity, out ValidationResult validationResult)
		{
			validationResult = new ValidationResult();

			if (!entity.Items.Any())
				validationResult.AddValidationMessage(Resource.ASaleMustHaveAtLeastOneItem);

			if (entity.Seller == null || entity.Seller.Id == 0)
				validationResult.AddValidationMessage(Resource.ASaleMusHaveAValidSeller);

			return validationResult.IsValid;
		}
	}
}
