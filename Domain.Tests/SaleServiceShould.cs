using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Domain.Validators;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Domain.Tests
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
			var sale = new Sale()
			{
				Seller = new Seller() { Id = 1 }
			};

			sale.AddItem(new SaleItem { Product = new Product { Id = 1 } });

			SaleService.Insert(sale);

			Assert.Pass();
		}

		[Test]
		public void Not_throw_entity_validation_exception_when_try_to_insert_sale_that_have_a_valid_seller()
		{
			var sale = new Sale() 
			{ 
				Seller = new Seller() { Id = 1 }
			};

			sale.AddItem(new SaleItem { Product = new Product { Id = 1 } });

			SaleService.Insert(sale);

			Assert.Pass();
		}

		[Test]
		public void Update_all_unit_price_items_with_product_price_when_insert_new_sale()
		{
			var product1 = new Product { Id = 1, Price = 10 };
			var product2 = new Product { Id = 2, Price = 20 };


			var sale = new Sale()
			{
				Seller = new Seller() { Id = 1 },
				Items = new List<SaleItem>
				{
					new SaleItem{ Amount = 1, Product = product1 },
					new SaleItem{ Amount = 1, Product = product2 },
				}
			};

			SaleService.Insert(sale);

			Assert.AreEqual(sale.Items[0].UnitPrice, product1.Price);
			Assert.AreEqual(sale.Items[1].UnitPrice, product2.Price);
		}

		[Test]
		public void Update_the_status_of_a_Waiting_Payment_sale_only_when_the_new_status_was_Payment_Accepted_or_Canceled()
		{
			var sale = new Sale() { Status = SaleStatus.WaitingPayment };

			//go to payment accepted
			SaleService.UpdateStatus(sale, SaleStatus.PaymentAccepted);
			Assert.AreEqual(sale.Status, SaleStatus.PaymentAccepted);

			//go to canceled
			sale.Status = SaleStatus.WaitingPayment;
			SaleService.UpdateStatus(sale, SaleStatus.Canceled);
			Assert.AreEqual(sale.Status, SaleStatus.Canceled);

			//go to shipped to carrier
			sale.Status = SaleStatus.WaitingPayment;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.ShippedToCarrier));

			//go to delivered
			sale.Status = SaleStatus.WaitingPayment;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.Delivered));

		}

		[Test]
		public void Update_the_status_of_a_Accepted_Payment_sale_only_when_the_new_status_was_Shipped_to_Carrier_or_Canceled()
		{
			var sale = new Sale() { Status = SaleStatus.PaymentAccepted };

			//go to canceled
			SaleService.UpdateStatus(sale, SaleStatus.Canceled);
			Assert.AreEqual(sale.Status, SaleStatus.Canceled);

			//go to shipped to carrier
			sale.Status = SaleStatus.PaymentAccepted;
			SaleService.UpdateStatus(sale, SaleStatus.ShippedToCarrier);

			//go to waiting payment
			sale.Status = SaleStatus.PaymentAccepted;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.WaitingPayment));

			//go to delivered
			sale.Status = SaleStatus.PaymentAccepted;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.Delivered));
		}

		[Test]
		public void Update_the_status_of_a_Shipped_to_Carrier_sale_only_when_the_new_status_was_Delivered()
		{
			var sale = new Sale() { Status = SaleStatus.ShippedToCarrier };

			//go to delivered
			SaleService.UpdateStatus(sale, SaleStatus.Delivered);
			Assert.AreEqual(sale.Status, SaleStatus.Delivered);

			//go to canceled
			sale.Status = SaleStatus.ShippedToCarrier;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.Canceled));

			//go to payment accepted
			sale.Status = SaleStatus.ShippedToCarrier;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.PaymentAccepted));

			//go to waiting payment
			sale.Status = SaleStatus.ShippedToCarrier;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.WaitingPayment));
		}

		[Test]
		public void Can_not_update_the_status_of_a_Delivered_sale()
		{
			var sale = new Sale() { Status = SaleStatus.Delivered };

			//go to waiting payment
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.WaitingPayment));

			//go to payment accepted
			sale.Status = SaleStatus.Delivered;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.PaymentAccepted));

			//go to canceled
			sale.Status = SaleStatus.Delivered;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.Canceled));

			//go to shipped to carrier
			sale.Status = SaleStatus.Delivered;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.ShippedToCarrier));

			//go to delivered
			sale.Status = SaleStatus.Delivered;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.Delivered));
		}

		[Test]
		public void Can_not_update_the_status_of_a_Canceled_sale()
		{
			var sale = new Sale() { Status = SaleStatus.Canceled };

			//go to waiting payment
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.WaitingPayment));

			//go to payment accepted
			sale.Status = SaleStatus.Canceled;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.PaymentAccepted));

			//go to shipped to carrier
			sale.Status = SaleStatus.Canceled;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.ShippedToCarrier));

			//go to delivered
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.Delivered));

			//go to canceled
			sale.Status = SaleStatus.Canceled;
			Assert.Throws<EntityValidationException>(() => SaleService.UpdateStatus(sale, SaleStatus.Canceled));
		}
	}
}