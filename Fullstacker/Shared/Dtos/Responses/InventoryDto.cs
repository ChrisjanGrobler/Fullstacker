namespace Shared.Dtos.Responses
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}