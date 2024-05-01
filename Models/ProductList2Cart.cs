namespace Assignment_2_NEW.Models
{
    public class ProductList2Cart
    {
        private readonly AssignmentDatabaseContext Databass = new AssignmentDatabaseContext();
        public List<Product> FindAll()
        {
            var Action = Databass.Products.ToList();
            return Action;
        }
        public Product? Find(string ItemID)
        {
            var Action = Databass.Products.Find(ItemID);
            return Action;
        }
    }
}
