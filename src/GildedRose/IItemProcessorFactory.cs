using GildedRoseKata.ItemProcessors;

namespace GildedRoseKata;

public interface IItemProcessorFactory
{
    public IItemProcessor GetItemProcessor(string itemName);
}