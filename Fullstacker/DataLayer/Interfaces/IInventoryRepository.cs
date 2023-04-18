namespace DataLayer.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IList<Entities.Inventory>> Get();
    }
}
