namespace GildedRoseKata.ItemProcessors;

internal class LegendaryItemProcessor : IItemProcessor
{
    public bool CanHandleItem(string itemName) =>
        itemName.Equals("Sulfuras, Hand of Ragnaros", StringComparison.Ordinal);

    public void UpdateItem(Item item)
    {
    }
}