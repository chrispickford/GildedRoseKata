using GildedRoseKata.ItemProcessors;

namespace GildedRoseKata;

internal class ItemProcessorFactory(IEnumerable<IItemProcessor> itemProcessors)
    : IItemProcessorFactory
{
    public IItemProcessor GetItemProcessor(string itemName)
    {
        return itemProcessors.FirstOrDefault(itemProcessor => itemProcessor.CanHandleItem(itemName));
    }
}