namespace Sales.Domain.Entities
{
	public enum SaleStatus
	{
		WaitingPayment = 0,
		PaymentAccepted = 1,
		Canceled = 2,
		ShippedToCarrier = 3,
		Delivered = 4
	}
}