using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Contracts;
using Domain.Validation;
using Domain.Validation.Contracts;

namespace Domain.Services
{
	public class SaleService : ServiceBase<Sale>, ISaleService
	{
		private IValidator<Sale> SaleValidator { get; }

		public SaleService(ISaleRepository saleRepository, IValidator<Sale> saleValidator) : base(saleRepository)
		{
			SaleValidator = saleValidator;
		}


		public override void Insert(Sale sale)
		{
			ThrowExceptionIfSaleIsInvalid(sale);

			UpdateUnitPriceOfItems(sale);

			base.Insert(sale);
		}

		private void UpdateUnitPriceOfItems(Sale sale)
		{
			foreach (var item in sale.Items)
			{
				item.UnitPrice = item.Product.Price;
			}
		}

		public void UpdateStatus(Sale sale, SaleStatus newStatus)
		{
			sale.UpdateStatus(newStatus);

			Update(sale);
		}

		private void ThrowExceptionIfSaleIsInvalid(Sale sale)
		{
			if (!SaleValidator.Validate(sale, out ValidationResult validationResult))
				throw new EntityValidationException(validationResult.JoinMessages());
		}
	}
}
