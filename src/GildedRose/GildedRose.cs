using GildedRoseKata.ItemProcessors;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;
    private readonly ItemProcessorFactory _itemProcessorFactory;

    public GildedRose(IList<Item> items)
    {
        _items = items;

        IEnumerable<IItemProcessor> itemProcessors =
        [
            new AgedBrieItemProcessor(),
            new BackstagePassItemProcessor(),
            new LegendaryItemProcessor(),
            new GenericItemProcessor()
        ];

        _itemProcessorFactory = new ItemProcessorFactory(itemProcessors);
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            ProcessItem(item);
        }
    }

    private void ProcessItem(Item item) =>
        _itemProcessorFactory.GetItemProcessor(item.Name)?.UpdateItem(item);
}