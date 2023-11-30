namespace StoreApp.Data.Concrete;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty; // Telefon => telefon => Beyaz Eya => beyaz-esya
    public List<Product> Products { get; set; } = new();
}

// productId categoryId => 1 1 - 1 2
