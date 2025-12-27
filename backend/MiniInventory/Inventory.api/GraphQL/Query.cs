using Inventory.Api.Data;
using Inventory.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.GraphQL;

public class Query
{
    // GraphQL field: items
    public async Task<List<Item>> GetItems([Service] AppDbContext db)
    {
        return await db.Items
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .ToListAsync();
    }
}