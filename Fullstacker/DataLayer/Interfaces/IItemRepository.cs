namespace DataLayer.Interfaces
{
    public interface IItemRepository
    {
        Task<IList<Entities.Item>> Get();
        Task<Entities.Item> Get(int id);
        Task Delete(Entities.Item item);
        Task<Entities.Item> Create(Entities.Item item);
        Task<Entities.Item> Update(Entities.Item item);
    }
}