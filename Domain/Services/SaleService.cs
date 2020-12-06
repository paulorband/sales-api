using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Contracts;
using Domain.Validators;
using Domain.Validators.Contracts;
using System;

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

			base.Insert(sale);
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
