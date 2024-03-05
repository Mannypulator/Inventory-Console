using InventoryManagementSystem.Dtos;

namespace InventoryManagementSystem.Service;

public interface IInventoryItemService
{
    List<InventoryItemDto> GetInventoryItems();
    string CreatInventoryItem(InventoryItemForCreationDto request);
    string UpdateInventoryItem(InventoryItemForUpdateDto request);
    string DeleteInventoryItem(int id);
}