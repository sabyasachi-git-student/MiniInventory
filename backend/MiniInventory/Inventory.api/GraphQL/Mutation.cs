using Inventory.Api.Data;
using Inventory.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.GraphQL;

public class Mutation
{
    // GraphQL mutation: addItem(name, type, quantity)
    public async Task<Item> AddItem(
        string name,
        string type,
        int quantity,
        [Service] AppDbContext db)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new GraphQLException("Name is required.");

        if (string.IsNullOrWhiteSpace(type))
            throw new GraphQLException("Type is required.");

        if (quantity < 0)
            throw new GraphQLException("Quantity cannot be negative.");

        var item = new Item
        {
            Name = name.Trim(),
            Type = type.Trim(),
            Quantity = quantity
        };

        db.Items.Add(item);
        await db.SaveChangesAsync();
        return item;
    }

    // GraphQL mutation: deleteItem(id)
    public async Task<bool> DeleteItem(int id, [Service] AppDbContext db)
    {
        var item = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
        if (item == null) return false;

        db.Items.Remove(item);
        await db.SaveChangesAsync();
        return true;
    }

    // GraphQL mutation: updateQuantity(id, quantity)
    public async Task<Item?> UpdateQuantity(int id, int quantity, [Service] AppDbContext db)
    {
        if (quantity < 0)
            throw new GraphQLException("Quantity cannot be negative.");

        var item = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
        if (item == null) return null;

        item.Quantity = quantity;
        await db.SaveChangesAsync();
        return item;
    }
}
