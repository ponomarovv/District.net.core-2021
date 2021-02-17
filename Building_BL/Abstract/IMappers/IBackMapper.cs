namespace District.Bl.Abstract.IMappers
{
    public interface IBackMapper<TEntity, TModel> : IMapper<TEntity, TModel>
    {
        TEntity MapBack(TModel model);
    }
}
