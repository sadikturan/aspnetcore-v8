namespace StoreApp.Data.Concrete;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty; 
    public List<Product> Products { get; set; } = new();
}

