using Sales.Domain.Entities;
using Sales.Domain.Repositories;
using Sales.Domain.Services.Contracts;
using System.Collections.Generic;

namespace Sales.Domain.Services
{
	public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
	{
		public ServiceBase(IRepositoryBase<TEntity> repository)
		{
			Repository = repository;
		}

		protected IRepositoryBase<TEntity> Repository { get; }

		public void Delete(TEntity entity)
		{
			Repository.Delete(entity);
		}

		public IList<TEntity> GetAll()
		{
			return Repository.GetAll();
		}

		public TEntity GetById(long id)
		{
			return Repository.GetById(id);
		}

		public void Insert(TEntity entity)
		{
			Repository.Insert(entity);
		}

		public void Update(TEntity entity)
		{
			Repository.Update(entity);
		}
	}
}