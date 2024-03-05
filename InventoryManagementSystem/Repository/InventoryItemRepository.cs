using InventoryManagementSystem.Entity;

namespace InventoryManagementSystem.Repository;

public class InventoryItemRepository : IInventoryItemRepository
{
    private readonly List<InventoryItem> InventoryInMemeory; // database
    public void CreateItem(InventoryItem item) => InventoryInMemeory.Add(item);
  

    public void UpdateItem(InventoryItem item)
    {
        // loop through the inventory list inmemory
        foreach (var inventoryItem in InventoryInMemeory.Where(inventoryItem => inventoryItem.Id == item.Id))
        {
            inventoryItem.Name = item.Name ?? inventoryItem.Name;
            inventoryItem.Quantity = item.Quantity <= 0 ? inventoryItem.Quantity : item.Quantity;
            inventoryItem.DateUpdated = DateTime.Now;
        }
       
    }

    public void DeleteItem(long id)
    {
        foreach (var item in InventoryInMemeory.Where(item => item.Id == id))
        {
            InventoryInMemeory.Remove(item);
            break;
        }
    }

    public InventoryItem GetItem(long id)
    {
        foreach (var item in InventoryInMemeory)
        {
            if (item.Id == id)
            {
                return item;
                
            }
        }
        return null;
    }

    public List<InventoryItem> GetItems()
    {
        return InventoryInMemeory;
    }
}