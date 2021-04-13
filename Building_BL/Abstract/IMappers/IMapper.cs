namespace District.Bl.Abstract.IMappers
{
    public interface IMapper<TEntity, TModel>
    {
        TModel Map(TEntity entity);
    }
}
