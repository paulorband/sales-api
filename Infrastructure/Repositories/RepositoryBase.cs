using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.EntityFramework.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
	{
		public RepositoryBase(SalesContext salesContext)
		{
			SalesContext = salesContext;
			Entities = SalesContext.Set<TEntity>();
		}

		protected SalesContext SalesContext { get; }
		protected DbSet<TEntity> Entities;

		public virtual void Delete(TEntity entity)
		{
			Entities.Remove(entity);

			SalesContext.SaveChanges();
		}

		public virtual IList<TEntity> GetAll()
		{
			return Entities.ToList();
		}

		public virtual TEntity GetById(long id)
		{
			return Entities.Find(id);
		}

		public virtual void Insert(TEntity entity)
		{
			Entities.Add(entity);

			SalesContext.SaveChanges();
		}

		public virtual void Update(TEntity entity)
		{
			Entities.Update(entity);

			SalesContext.SaveChanges();
		}
	}
}
