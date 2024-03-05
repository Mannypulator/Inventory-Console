using InventoryManagementSystem.Entity;

namespace InventoryManagementSystem.Repository;

public interface IInventoryItemRepository
{
    void CreateItem(InventoryItem item);
    void UpdateItem(InventoryItem item);
    void DeleteItem(long id);
    InventoryItem GetItem(long id);
    List<InventoryItem> GetItems();
}