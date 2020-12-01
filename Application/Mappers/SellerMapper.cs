using Application.Mappers.Contracts;
using Application.Models;
using Domain.Entities;

namespace Application.Mappers
{
	public class SellerMapper : IMapper<Seller, SellerModel>
	{
		public Seller ToEntity(SellerModel model)
		{
			return new Seller
			{
				Id = model.Id,
				Cpf = model.Cpf,
				Email = model.Email,
				Name = model.Name,
				Telefone = model.Telefone
			};
		}

		public SellerModel ToModel(Seller entity)
		{
			return new SellerModel
			{
				Id = entity.Id,
				Cpf = entity.Cpf,
				Email = entity.Email,
				Name = entity.Name,
				Telefone = entity.Telefone
			};
		}
	}
}
