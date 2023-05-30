namespace DataLayer.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IList<Shared.Dtos.Responses.InventoryDto>> Get();
        Task<Shared.Dtos.Responses.InventoryDto> Get(int id);
        Task Delete(int id);
        Task<Shared.Entities.Inventory> Create(Shared.Entities.Inventory inventory);
        Task<Shared.Entities.Inventory> Update(int id, int itemId ,int quantity);
    }
}
