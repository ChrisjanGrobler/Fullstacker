using Shared.Entities;

namespace DataLayer.Interfaces
{
    public interface IItemRepository
    {
        Task<IList<Item>> Get();
        Task<Item> Get(int id);
        Task Delete(int id);
        Task<Item> Create(Item item);
        Task<Item> Update(int id, string name, string description);
    }
}