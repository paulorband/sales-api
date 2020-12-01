using Application.Mappers.Contracts;
using Application.Models;
using Domain.Entities;

namespace Application.Mappers
{
	public class SaleItemMapper : IMapper<SaleItem, SaleItemModel>
	{
		public SaleItemMapper(IMapper<Product, ProductModel> productMapper)
		{
			ProductMapper = productMapper;
		}

		protected IMapper<Product, ProductModel> ProductMapper { get; }

		public SaleItem ToEntity(SaleItemModel model)
		{
			return new SaleItem
			{
				Id = model.Id,
				Amount = model.Amount,
				Product = ProductMapper.ToEntity(model.Product),
				UnitPrice = model.UnitPrice
			};
		}

		public SaleItemModel ToModel(SaleItem entity)
		{
			return new SaleItemModel
			{
				Id = entity.Id,
				Amount = entity.Amount,
				Product = ProductMapper.ToModel(entity.Product),
				UnitPrice = entity.UnitPrice
			};
		}
	}
}
