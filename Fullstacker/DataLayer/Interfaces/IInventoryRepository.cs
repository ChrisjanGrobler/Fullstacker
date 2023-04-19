namespace DataLayer.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IList<Entities.Inventory>> Get();
        Task<Entities.Inventory> Get(int id);
        Task Delete(int id);
        Task<Entities.Inventory> Create(Entities.Inventory inventory);
        Task<Entities.Inventory> Update(int id, int itemId ,int quantity);
    }
}
