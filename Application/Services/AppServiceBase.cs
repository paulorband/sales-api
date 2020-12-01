using Application.Mappers.Contracts;
using Application.Models;
using Application.Services.Contracts;
using Domain.Entities;
using Domain.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
	public class AppServiceBase<TEntity, TModel> : IAppServiceBase<TEntity, TModel> 
		where TEntity : EntityBase 
		where TModel : ModelBase
	{
		protected IServiceBase<TEntity> Service { get; }
		protected IMapper<TEntity, TModel> Mapper { get; }

		public AppServiceBase(IServiceBase<TEntity> service, IMapper<TEntity, TModel> mapper)
		{
			Service = service;
			Mapper = mapper;
		}

		public void Delete(TModel model)
		{
			Service.Delete(Mapper.ToEntity(model));
		}

		public IList<TModel> GetAll()
		{
			var entities = Service.GetAll();

			return MapperListToModel(entities);
		}

		public TModel GetById(long id)
		{
			return Mapper.ToModel(Service.GetById(id));
		}

		public void Insert(TModel model)
		{
			Service.Insert(Mapper.ToEntity(model));
		}

		public void Update(TModel model)
		{
			Service.Update(Mapper.ToEntity(model));
		}
		private List<TModel> MapperListToModel(IList<TEntity> entities)
		{
			return entities.Select(e => Mapper.ToModel(e)).ToList();
		}
	}
}
