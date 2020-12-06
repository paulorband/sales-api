using Domain.Validators.Contracts;
using Resources;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public class Sale : EntityBase
	{
		public Seller Seller { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public SaleStatus Status { get; set; } = SaleStatus.WaitingPayment;
		public IList<SaleItem> Items { get; set; } = new List<SaleItem>();

		public void AddItem(SaleItem saleItem)
		{
			Items.Add(saleItem);
		}

		public void RemoveItem(SaleItem saleItem)
		{
			Items.Remove(saleItem);
		}

		public void UpdateStatus(SaleStatus status)
		{
			ThrowExceptionIfCanNotGoToNewStatus(status);

			Status = status;
		}

		private void ThrowExceptionIfCanNotGoToNewStatus(SaleStatus newStatus)
		{
			switch (Status)
			{
				case SaleStatus.WaitingPayment:
					if (newStatus != SaleStatus.Canceled && newStatus != SaleStatus.PaymentAccepted)
						throw new EntityValidationException(string.Format(Resource.SaleCantGoToX, newStatus.ToString()));
					break;

				case SaleStatus.PaymentAccepted:
					if (newStatus != SaleStatus.Canceled && newStatus != SaleStatus.ShippedToCarrier)
						throw new EntityValidationException(string.Format(Resource.SaleCantGoToX, newStatus.ToString()));
					break;

				case SaleStatus.ShippedToCarrier:
					if (newStatus != SaleStatus.Delivered)
						throw new EntityValidationException(string.Format(Resource.SaleCantGoToX, newStatus.ToString()));
					break;

				case SaleStatus.Canceled:
					throw new EntityValidationException(Resource.ACanceledSaleCantBeUpdated);

				case SaleStatus.Delivered:
					throw new EntityValidationException(Resource.ADeliveredSaleCantBeUpdated);
			}
		}
	}
}
