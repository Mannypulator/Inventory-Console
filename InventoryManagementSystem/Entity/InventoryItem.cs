namespace InventoryManagementSystem.Entity;

public class InventoryItem
{
    public long Id { get; set;}
    public string Name { get; set; }
    public int Quantity { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    
}