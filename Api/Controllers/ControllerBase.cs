using Application.Models;
using Application.Services.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ControllerBase<TEntity, TModel> : ApiControllerBase
		where TEntity : EntityBase
		where TModel : ModelBase
	{
		protected IAppServiceBase<TEntity, TModel> AppService { get; }

		public ControllerBase(IAppServiceBase<TEntity, TModel> appService)
		{
			AppService = appService;
		}
		
		/// <summary>
		/// Returns all Items
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<TModel> Get()
		{
			return AppService.GetAll();
		}

		/// <summary>
		/// Get Item by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public TModel Get(int id)
		{
			return AppService.GetById(id);
		}

		/// <summary>
		/// Create a new Item
		/// </summary>
		/// <param name="model"></param>
		[HttpPost]
		public void Post([FromBody] TModel model)
		{
			AppService.Insert(model);
		}

		/// <summary>
		/// Update a Item
		/// </summary>
		/// <param name="model"></param>
		[HttpPut]
		public void Put([FromBody] TModel model)
		{
			AppService.Update(model);
		}

		/// <summary>
		/// Delete a Item by id
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			AppService.Delete(id);
		}
	}
}
