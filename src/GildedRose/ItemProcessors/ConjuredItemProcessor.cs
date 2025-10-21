namespace GildedRoseKata.ItemProcessors;

internal class ConjuredItemProcessor : IItemProcessor
{
    public bool CanHandleItem(string itemName) =>
        itemName.StartsWith("Conjured", StringComparison.Ordinal);

    public void UpdateItem(Item item)
    {
        ReduceItemQuality(item);

        item.SellIn--;

        if (item.SellIn < 0)
        {
            ReduceItemQuality(item);
        }
    }

    private static void ReduceItemQuality(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality--;
        }

        if (item.Quality > 0)
        {
            item.Quality--;
        }
    }
}