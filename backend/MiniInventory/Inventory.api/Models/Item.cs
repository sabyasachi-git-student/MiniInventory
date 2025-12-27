namespace Inventory.Api.Models;

public class Item
{
    public int Id { get; set; }             // SQLite integer primary key (auto)
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
    public int Quantity { get; set; }
}
