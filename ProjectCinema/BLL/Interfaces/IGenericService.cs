namespace ProjectCinema.BLL.Interfaces
{
    public interface IGenericService<TDTO, TEntity> where TEntity : class
    {
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO> GetByIdAsync(int entityId);
    }
}
