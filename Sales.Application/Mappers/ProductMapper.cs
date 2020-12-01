using Sales.Application.Mappers.Contracts;
using Sales.Application.Models;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Mappers
{
	public class ProductMapper : IMapper<Product, ProductModel>
	{
		public Product ToEntity(ProductModel model)
		{
			return new Product
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price
			};
		}

		public ProductModel ToModel(Product entity)
		{
			return new ProductModel
			{
				Id = entity.Id,
				Name = entity.Name,
				Price = entity.Price
			};
		}
	}
}
