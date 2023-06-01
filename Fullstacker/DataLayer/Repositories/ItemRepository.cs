using DataLayer.Contexts;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace DataLayer.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _dataContext;

        public ItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IList<Item>> Get()
         => await _dataContext.Item.ToListAsync();

        public async Task<Item> Get(int id)
            => await _dataContext.Item.FirstOrDefaultAsync(x => x.Id == id);

        public async Task Delete(int id)
        {
            var item = new Item { Id = id };
            _dataContext.Item.Remove(item); 

            await _dataContext.SaveChangesAsync();
        }

        public async Task<Item> Create(Item item)
        {
            _dataContext.Item.Add(item);
            await _dataContext.SaveChangesAsync();

            return item;
        }

        public async Task<Item> Update(int id, string name, string description)
        {
            var item = new Item { Id = id, Description = description, Name = name };

            _dataContext.Item.Update(item);
            await _dataContext.SaveChangesAsync();

            return item;
        }
    }
}