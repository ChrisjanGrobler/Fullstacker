namespace DataLayer.Interfaces
{
    public interface IItemRepository
    {
        Task<IList<Entities.Item>> Get();
    }
}