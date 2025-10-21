using GildedRoseKata.ItemProcessors;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    private readonly ItemProcessorFactory _itemProcessorFactory;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;

        IEnumerable<IItemProcessor> itemProcessors =
        [
            new AgedBrieItemProcessor(),
            new BackstagePassItemProcessor(),
            new LegendaryItemProcessor(),
            new ConjuredItemProcessor(),
            new GenericItemProcessor()
        ];

        _itemProcessorFactory = new ItemProcessorFactory(itemProcessors);
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            ProcessItem(item);
        }
    }

    private void ProcessItem(Item item) =>
        _itemProcessorFactory.GetItemProcessor(item.Name)?.UpdateItem(item);
}