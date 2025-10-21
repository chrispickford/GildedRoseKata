namespace GildedRoseKata.ItemProcessors;

internal class AgedBrieItemProcessor : IItemProcessor
{
    public bool CanHandleItem(string itemName) =>
        itemName.Equals("Aged Brie", StringComparison.Ordinal);

    public void UpdateItem(Item item)
    {
        item.SellIn--;

        if (item.Quality >= 50)
        {
            return;
        }

        item.Quality++;

        if (item.SellIn < 0)
        {
            item.Quality++;
        }
    }
}