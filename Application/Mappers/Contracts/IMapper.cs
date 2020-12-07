namespace Application.Mappers.Contracts
{
	public interface IMapper<TEntity, TModel>
	{
		TEntity ToEntity(TModel model);
		TModel ToModel(TEntity entity);
	}
}
