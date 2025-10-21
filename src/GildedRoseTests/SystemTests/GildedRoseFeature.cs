using GildedRoseKata;
using Xunit.Gherkin.Quick;

namespace GildedRoseTests.SystemTests;

[FeatureFile("./SystemTests/GildedRose.feature")]
public class GildedRoseFeature : Feature
{
    private List<Item> _items;
    private List<Item> _originalItems;

    [Given(@"I have an item")]
    public void I_have_an_item()
    {
        _items =
        [
            new Item { Name = "Test Item", Quality = 10, SellIn = 10 }
        ];
    }

    [Given(@"the item is named {string}")]
    [And(@"the item is named {string}")]
    public void The_item_is_named(string itemName)
    {
        _items.Single().Name = itemName;
    }

    [Given(@"the item has a SellIn value of {int}")]
    [And(@"the item has a SellIn value of {int}")]
    public void The_item_has_a_sellIn_value_of(int sellInValue)
    {
        _items.Single().SellIn = sellInValue;
    }

    [Given(@"the item has a Quality value of {int}")]
    [And(@"the item has a Quality value of {int}")]
    public void The_item_has_a_Quality_value_of(int qualityValue)
    {
        _items.Single().Quality = qualityValue;
    }

    [When(@"the items are updated at the end of the day")]
    public void The_items_are_updated_at_the_end_of_the_day()
    {
        _originalItems = CloneItems(_items);

        new GildedRose(_items).UpdateQuality();
    }

    [Then(@"the SellIn value is lowered")]
    public void The_SellIn_value_is_lowered()
    {
        Assert.All(_items, (item, i) => Assert.Equal(_originalItems[i].SellIn - 1, item.SellIn));
    }

    [And(@"the Quality value is lowered")]
    public void The_Quality_value_is_lowered()
    {
        Assert.All(_items, (item, i) => Assert.Equal(_originalItems[i].Quality - 1, item.Quality));
    }

    [Then(@"the Quality value is lowered twice")]
    public void The_Quality_value_is_lowered_twice()
    {
        var item = _items.Single();
        var originalItem = _originalItems.Single();

        Assert.Equal(originalItem.Quality - 2, item.Quality);
    }

    [Then(@"the Quality value is not increased above {int}")]
    public void the_Quality_value_is_not_increased_above(int maxValue)
    {
        var item = _items.Single();

        Assert.False(item.Quality > maxValue);
    }

    [Then(@"the SellIn value equals {int}")]
    [And(@"the SellIn value equals {int}")]
    public void the_SellIn_value_equals(int sellInValue)
    {
        var item = _items.Single();

        Assert.Equal(sellInValue, item.SellIn);
    }

    [Then(@"the Quality value equals {int}")]
    [And(@"the Quality value equals {int}")]
    public void the_Quality_value_equals(int qualityValue)
    {
        var item = _items.Single();

        Assert.Equal(qualityValue, item.Quality);
    }

    private static List<Item> CloneItems(IList<Item> items) => items.Select(item =>
            new Item { Name = item.Name, Quality = item.Quality, SellIn = item.SellIn })
        .ToList();
}