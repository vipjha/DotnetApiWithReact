namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string BuyerId { get; set; }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public List<BasketItem> Items { get; set; } = new();

        public void AddItem(Product  product, int quantity)
        {
            if(Items.All(items => items.ProductId !=product.Id))
            {
                Items.Add(new BasketItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }

            var existingItem= Items.FirstOrDefault(item => item.ProductId == product.Id);
            if(existingItem != null) existingItem.Quantity  += quantity;
        }

        public void RemoveItem(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.ProductId == productId);
            if (item == null) return;
            item.Quantity -= quantity;
            if(item.Quantity==0)Items.Remove(item);
        }
    }
}
