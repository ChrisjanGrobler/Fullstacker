using Shared.Dtos.Responses;
using Shared.Entities;

namespace Shared.Utilities
{
    public static class Converter
    {
        public static IList<InventoryDto> GetInventoryDtos(this List<Inventory> entities)
        {
            return entities.Select(entity => new InventoryDto
            {
                Id = entity.Id,
                Name = entity.Item.Name,
                CreatedOn = entity.CreatedOn,
                Quantity = entity.Quantity,
                Description = entity.Item.Description
            }).ToList();
        }

        public static InventoryDto GetInventoryDto(this Inventory entity)
        {
            return new InventoryDto
            {
                Id = entity.Id,
                Name = entity.Item.Name,
                CreatedOn = entity.CreatedOn,
                Quantity = entity.Quantity,
                Description = entity.Item.Description
            };
        }    
        public static Inventory CreateInventory(CreateInventoryDto entity)
        {
            return new Inventory
            {
                ItemId = entity.ItemId,
                Quantity = entity.Quantity,
                CreatedOn = DateTimeOffset.UtcNow,
            };
        }
    }
}