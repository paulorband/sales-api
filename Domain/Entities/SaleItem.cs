namespace Domain.Entities
{
	public class SaleItem : EntityBase
	{
		public Sale Sale { get; set; }
		public Product Product { get; set; }
		public int Amount { get; set; }
		public decimal? UnitPrice { get; set; }
		public decimal TotalPrice => Amount * UnitPrice ?? 0;
	}
}
