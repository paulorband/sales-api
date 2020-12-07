using Domain.Entities;
using Domain.Validation.Contracts;
using Resources;
using System.Linq;

namespace Domain.Validation
{
	public class SaleValidator : IValidator<Sale>
	{
		public bool Validate(Sale sale, out ValidationResult validationResult)
		{
			validationResult = new ValidationResult();

			if (!sale.Items.Any())
				validationResult.AddValidationMessage(Resource.ASaleMustHaveAtLeastOneItem);
			
			ValidateSeller(sale, validationResult);

			ValidateItems(sale, validationResult);

			return validationResult.IsValid;
		}

		private static void ValidateSeller(Sale sale, ValidationResult validationResult)
		{
			if (sale.Seller == null || sale.Seller.Id == 0)
				validationResult.AddValidationMessage(Resource.ASaleMusHaveAValidSeller);
		}

		private void ValidateItems(Sale sale, ValidationResult validationResult)
		{
			for (var i = 0; i < sale.Items.Count; i++)
			{
				var item = sale.Items[0];

				if (item.Product == null || item.Product.Id == 0)
					validationResult.AddValidationMessage(string.Format(Resource.TheItemXHaveAInvalidProduct, i + 1));
			}
		}
	}
}
