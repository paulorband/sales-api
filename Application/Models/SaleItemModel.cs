namespace Application.Models
{
	public class SaleItemModel : ModelBase
	{
		public ProductModel Product { get; set; }
		public int Amount { get; set; }
		public decimal? UnitPrice { get; set; }
		public decimal TotalPrice => Amount * UnitPrice ?? 0;
	}
}