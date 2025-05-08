namespace ProductInventoryAPI.Models {
    public class UpdateProductDto {
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
