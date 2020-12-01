using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Contracts;
using System.Collections.Generic;

namespace Domain.Services
{
	public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
	{
		public ServiceBase(IRepositoryBase<TEntity> repository)
		{
			Repository = repository;
		}

		protected IRepositoryBase<TEntity> Repository { get; }

		public virtual void Delete(TEntity entity)
		{
			Repository.Delete(entity);
		}

		public virtual IList<TEntity> GetAll()
		{
			return Repository.GetAll();
		}

		public virtual TEntity GetById(long id)
		{
			return Repository.GetById(id);
		}

		public virtual void Insert(TEntity entity)
		{
			Repository.Insert(entity);
		}

		public virtual void Update(TEntity entity)
		{
			Repository.Update(entity);
		}
	}
}