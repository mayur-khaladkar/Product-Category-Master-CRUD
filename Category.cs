namespace ProductCategory.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Navigation Property
        public virtual ICollection<Product> Products { get; set; }
    }
}
