using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

		public void Delete(TEntity entity)
		{
			Entities.Remove(entity);

			SalesContext.SaveChanges();
		}

		public IList<TEntity> GetAll()
		{
			return Entities.ToList();
		}

		public TEntity GetById(long id)
		{
			return Entities.SingleOrDefault(e => e.Id == id);
		}

		public void Insert(TEntity entity)
		{
			Entities.Add(entity);

			SalesContext.SaveChanges();
		}

		public void Update(TEntity entity)
		{
			Entities.Update(entity);

			SalesContext.SaveChanges();
		}
	}
}
