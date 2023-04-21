using DataLayer.Contexts;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext _dataContext;

        public InventoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IList<Entities.Inventory>> Get()
        => await _dataContext.Inventory.Include(x => x.Item).ToListAsync();


        public async Task<Entities.Inventory> Get(int id)
            => await _dataContext.Inventory.Include(x => x.Item).FirstOrDefaultAsync(x => x.Id == id);

        public async Task Delete(int id)
        {
            var inventory = new Entities.Inventory { Id = id };
            _dataContext.Inventory.Remove(inventory);

            await _dataContext.SaveChangesAsync();
        }
        public async Task<Entities.Inventory> Update(int id, int itemId, int quantity)
        {
            var inventory = await _dataContext.Inventory.FindAsync(id);

            inventory.ItemId = itemId;
            inventory.Quantity = quantity;
            inventory.UpdatedOn = DateTimeOffset.UtcNow;

            await _dataContext.SaveChangesAsync();

            return inventory;
        }

        public async Task<Entities.Inventory> Create(Entities.Inventory inventory)
        {
            inventory.CreatedOn = DateTime.Now;
            _dataContext.Inventory.Add(inventory);
            await _dataContext.SaveChangesAsync();

            return inventory;
        }
    }
}
