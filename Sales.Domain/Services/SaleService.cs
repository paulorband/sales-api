using Sales.Domain.Entities;
using Sales.Domain.Repositories;
using Sales.Domain.Services.Contracts;
using Sales.Domain.Validators;
using Sales.Domain.Validators.Contracts;
using System;

namespace Sales.Domain.Services
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

		private void ThrowExceptionIfSaleIsInvalid(Sale sale)
		{
			if (!SaleValidator.Validate(sale, out ValidationResult validationResult))
				throw new EntityValidationException(validationResult.JoinMessages());
		}
	}
}
