﻿using DataLayer.Contexts;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Utilities;

namespace DataLayer.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext _dataContext;

        public InventoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IList<Shared.Dtos.Responses.InventoryDto>> Get()
        {
            var entities = await _dataContext.Inventory.Select(i => new Inventory
            {
                Id = i.Id,
                Quantity = i.Quantity,
                CreatedOn = i.CreatedOn,
                UpdatedOn = i.UpdatedOn,
                Item = new Item
                {
                    Id = i.Item.Id,
                    Name = i.Item.Name,
                    Description = i.Item.Description
                }
            }).ToListAsync();

            return entities.GetInventoryDtos();
        }

        public async Task<Inventory> Get(int id)
        {
            var inventory = await _dataContext.Inventory.Include(i => i.Item).Select(i => new Inventory
            {
                Id = i.Id,
                Quantity = i.Quantity,
                CreatedOn = i.CreatedOn,
                UpdatedOn = i.UpdatedOn,
                Item = new Item
                {
                    Id = i.Item.Id,
                    Name = i.Item.Name,
                    Description = i.Item.Description
                }
            }).FirstOrDefaultAsync(x => x.Id == id);

            return inventory ?? new Inventory();
        }

        public async Task Delete(int id)
        {
            var inventory = new Inventory { Id = id };
            _dataContext.Inventory.Remove(inventory);

            await _dataContext.SaveChangesAsync();
        }

        public async Task<Inventory> Update(int id, int itemId, int quantity)
        {
            var inventory = await _dataContext.Inventory.FindAsync(id);

            inventory.ItemId = itemId;
            inventory.Quantity = quantity;
            inventory.UpdatedOn = DateTimeOffset.UtcNow;

            await _dataContext.SaveChangesAsync();

            return inventory;
        }

        public async Task<Inventory> Create(Inventory inventory)
        {
            inventory.CreatedOn = DateTimeOffset.Now;
            _dataContext.Inventory.Add(inventory);
            await _dataContext.SaveChangesAsync();

            return inventory;
        }
    }
}