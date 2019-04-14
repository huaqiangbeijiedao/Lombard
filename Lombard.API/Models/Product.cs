
namespace Lombard.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product (ProductHistory productHistory)
        {
            this.Id = productHistory.Id;
            this.Name = productHistory.Name;
            this.Price = productHistory.Price;
            this.Quantity = productHistory.Quantity;
        }
        public Product ()
        {

        }
    }
}
