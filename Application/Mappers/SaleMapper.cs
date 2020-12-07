using Application.Mappers.Contracts;
using Application.Models;
using Domain.Entities;
using Domain.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
	public class SaleMapper : IMapper<Sale, SaleModel>
	{
		public SaleMapper(IMapper<Seller, SellerModel> sellerMapper,
			IMapper<SaleItem, SaleItemModel> saleItemMapper,
			ISellerService sellerService)
		{
			SellerMapper = sellerMapper;
			SaleItemMapper = saleItemMapper;
			SellerService = sellerService;
		}

		public IMapper<Seller, SellerModel> SellerMapper { get; }
		public IMapper<SaleItem, SaleItemModel> SaleItemMapper { get; }
		public ISellerService SellerService { get; }

		public Sale ToEntity(SaleModel model)
		{
			return new Sale
			{
				Id = model.Id,
				Date = model.Date,
				Status = model.Status,
				Seller = MapSeller(model),
				Items = MapItems(model)
			};
		}

		private Seller MapSeller(SaleModel model)
		{
			return SellerService.GetById(model.Seller?.Id ?? 0);
		}

		private List<SaleItem> MapItems(SaleModel model)
		{
			return model.Items.Select(item => SaleItemMapper.ToEntity(item)).ToList();
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
