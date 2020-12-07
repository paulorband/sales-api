using Application.Mappers.Contracts;
using Application.Models;
using Domain.Entities;
using Domain.Services.Contracts;
using System;

namespace Application.Mappers
{
	public class SaleItemMapper : IMapper<SaleItem, SaleItemModel>
	{
		public SaleItemMapper(IMapper<Product, ProductModel> productMapper, IProductService productService)
		{
			ProductMapper = productMapper;
			ProductService = productService;
		}

		protected IMapper<Product, ProductModel> ProductMapper { get; }
		public IProductService ProductService { get; }

		public SaleItem ToEntity(SaleItemModel model)
		{
			return new SaleItem
			{
				Id = model.Id,
				Amount = model.Amount,
				Product = GetProduct(model),
				UnitPrice = model.UnitPrice
			};
		}

		private Product GetProduct(SaleItemModel model)
		{
			return ProductService.GetById(model.Product?.Id ?? 0);
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
