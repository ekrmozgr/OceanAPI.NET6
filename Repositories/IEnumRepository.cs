namespace OceanAPI.NET6.Repositories
{
    public interface IEnumRepository<T> where T : class
    {
        Task<List<T>> Get();
    }
}
