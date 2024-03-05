using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Entity;
using InventoryManagementSystem.Repository;

namespace InventoryManagementSystem.Service;

public class InventoryItemService(IInventoryItemRepository inventoryItemRepository) : IInventoryItemService
{
    private readonly IInventoryItemRepository _inventoryItemRepository = inventoryItemRepository;

    public List<InventoryItemDto> GetInventoryItems()
    {
        var itemsFromRepository = _inventoryItemRepository.GetItems();
        
        var items = new List<InventoryItemDto>();

        foreach (var item in itemsFromRepository)
        {
            var itemDto = new InventoryItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Quantity = item.Quantity,
                DateUpdated = item.DateUpdated,
                DateCreated = item.DateCreated
            };
            
            items.Add(itemDto);
        }
        
        return items;
    }

    public string CreatInventoryItem(InventoryItemForCreationDto request)
    {

        if (ValidateInventoryItem(request.Name,request.Quantity)) return "Name and Quantity are required";
        var items = _inventoryItemRepository.GetItems();

        var item = new InventoryItem
        {
            Id = items.Count + 1,
            Name = request.Name,
            Quantity = request.Quantity,
            DateUpdated = DateTime.Now,
            DateCreated = DateTime.Now
        };
        
        _inventoryItemRepository.CreateItem(item);

        return "Inventory Item created successfully";
    }

    public string UpdateInventoryItem(InventoryItemForUpdateDto request)
    {
        if (ValidateInventoryItem(request.Name,request.Quantity)) return "Name and Quantity are required";
        
        var checkItem = _inventoryItemRepository.GetItem(request.Id);

        if(CheckInventoryItem(request.Id)) return "Item not found";

        var item = new InventoryItem
        {
            Id = request.Id,
            Name = request.Name,
            Quantity = request.Quantity
        };
        
        _inventoryItemRepository.UpdateItem(item);
        return "Inventory Item updated successfully";
    }

    public string DeleteInventoryItem(int id)
    {
        if(CheckInventoryItem(id)) return "Item not found";
        
        _inventoryItemRepository.DeleteItem(id);
        
        return "Inventory Item deleted successfully";
    }

    private bool ValidateInventoryItem(string name, int quantity)
    {
        return !string.IsNullOrEmpty(name) && quantity > 0;
    }

    private bool CheckInventoryItem(long id)
    {
        return _inventoryItemRepository.GetItem(id)!= null;
    }
}