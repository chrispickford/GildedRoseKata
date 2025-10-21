namespace GildedRoseKata.ItemProcessors;

public interface IItemProcessor
{
    public bool CanHandleItem(string itemName);
    public void UpdateItem(Item item);
}