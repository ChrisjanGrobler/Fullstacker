namespace DataLayer.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public int itemId { get; set; }
        public int quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
