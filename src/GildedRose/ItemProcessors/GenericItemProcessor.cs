namespace GildedRoseKata.ItemProcessors;

internal class GenericItemProcessor : IItemProcessor
{
    public bool CanHandleItem(string itemName) => true;

    public void UpdateItem(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality--;
        }

        item.SellIn--;

        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality--;
        }
    }
}