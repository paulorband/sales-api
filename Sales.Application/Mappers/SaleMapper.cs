using Sales.Application.Mappers.Contracts;
using Sales.Application.Models;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Application.Mappers
{
	public class SaleMapper : IMapper<Sale, SaleModel>
	{
		public SaleMapper(IMapper<Seller, SellerModel> sellerMapper, 
			IMapper<SaleItem, SaleItemModel> saleItemMapper)
		{
			SellerMapper = sellerMapper;
			SaleItemMapper = saleItemMapper;
		}

		public IMapper<Seller, SellerModel> SellerMapper { get; }
		public IMapper<SaleItem, SaleItemModel> SaleItemMapper { get; }

		public Sale ToEntity(SaleModel model)
		{
			return new Sale
			{
				Id = model.Id,
				Date = model.Date,
				Status = model.Status,
				Seller = SellerMapper.ToEntity(model.Seller),
				Items = MapItems(model)
			};
		}

		private List<SaleItem> MapItems(SaleModel model)
		{
			return model.Items.Select(s => SaleItemMapper.ToEntity(s)).ToList();
		}

		public SaleModel ToModel(Sale entity)
		{
			return new SaleModel
			{
				Id = entity.Id,
				Date = entity.Date,
				Status = entity.Status,
				Seller = SellerMapper.ToModel(entity.Seller),
				Items = MapItems(entity)
			};
		}

		private IList<SaleItemModel> MapItems(Sale entity)
		{
			return entity.Items.Select(s => SaleItemMapper.ToModel(s)).ToList();
		}
	}
}
