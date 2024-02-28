namespace StoreApp.Web.Models;

public class OrderModel
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string AddressLine { get; set; } = null!;
    public Cart Cart { get; set; } = null!;
}