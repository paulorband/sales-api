using Moq;
using NUnit.Framework;
using Sales.Domain.Entities;
using Sales.Domain.Repositories;
using Sales.Domain.Services;
using Sales.Domain.Validators;

namespace Sales.Domain.Tests
{
	public class SaleServiceShould
	{

		private SaleService SaleService;

		private Mock<ISaleRepository> SaleRepositoryMock = new Mock<ISaleRepository>();

		[SetUp]
		public void Setup()
		{
			SaleService = new SaleService(SaleRepositoryMock.Object, new SaleValidator());
		}

		[Test]
		public void Throw_entity_validation_exception_when_try_to_insert_sale_that_have_no_items()
		{
			var sale = new Sale();

			Assert.Throws<EntityValidationException>(() => SaleService.Insert(sale));
		}

		[Test]
		public void Throw_entity_validation_exception_when_try_to_insert_sale_that_have_no_valid_seller()
		{
			var sale = new Sale();

			Assert.Throws<EntityValidationException>(() => SaleService.Insert(sale));

			sale.Seller = new Seller();
			
			Assert.Throws<EntityValidationException>(() => SaleService.Insert(sale));
		}

		[Test]
		public void Not_throw_entity_validation_exception_when_try_to_insert_sale_that_have_items()
		{
			var sale = new Sale() { Seller = new Seller() { Id = 1 } };
			
			sale.AddItem(new SaleItem());

			SaleService.Insert(sale);

			Assert.Pass();
		}

		[Test]
		public void Not_throw_entity_validation_exception_when_try_to_insert_sale_that_have_a_valid_seller()
		{
			var sale = new Sale() { Seller = new Seller() { Id = 1 } };

			sale.AddItem(new SaleItem());

			SaleService.Insert(sale);

			Assert.Pass();
		}
	}
}