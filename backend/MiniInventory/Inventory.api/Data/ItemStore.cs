using Inventory.Api.Models;

namespace Inventory.Api.Data;

public class ItemStore
{
    private readonly List<Item> _items = new()
    {
        new Item { Id = 1, Name = "Pen", Type = "Stationery", Quantity = 10 },
        new Item { Id = 2, Name = "Rice", Type = "Food", Quantity = 25 }
    };

    private int _nextId = 3;

    public List<Item> GetAll() => _items;

    public Item Add(string name, string type, int quantity)
    {
        var item = new Item { Id = _nextId++, Name = name, Type = type, Quantity = quantity };
        _items.Add(item);
        return item;
    }

    public Item? UpdateQuantity(int id, int quantity)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item == null) return null;
        item.Quantity = quantity;
        return item;
    }

    public bool Delete(int id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item == null) return false;
        _items.Remove(item);
        return true;
    }
}
