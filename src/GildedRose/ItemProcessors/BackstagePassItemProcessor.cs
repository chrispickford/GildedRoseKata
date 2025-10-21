namespace GildedRoseKata.ItemProcessors;

internal class BackstagePassItemProcessor
    : IItemProcessor
{
    public bool CanHandleItem(string itemName) =>
        itemName.Equals("Backstage passes to a TAFKAL80ETC concert", StringComparison.Ordinal);

    public void UpdateItem(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }

        if (item.Quality < 50 && item.SellIn < 11)
        {
            item.Quality++;
        }

        if (item.Quality < 50 && item.SellIn < 6)
        {
            item.Quality++;
        }

        item.SellIn--;

        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
    }
}