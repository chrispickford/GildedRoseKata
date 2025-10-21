using GildedRoseKata;
using GildedRoseKata.ItemProcessors;

namespace GildedRoseTests.UnitTests.ItemProcessors;

public class LegendaryItemProcessorTests
{
    private readonly LegendaryItemProcessor _sut = new();

    [Theory]
    [InlineData("Sulfuras, Hand of Ragnaros", true)]
    [InlineData("Sulfuras", false)]
    [InlineData("Legendary Item", false)]
    [InlineData("", false)]
    [InlineData(" ", false)]
    public void CanHandleItem_ReturnsExpectedResult(string itemName, bool expectedResult)
    {
        // Act
        var result = _sut.CanHandleItem(itemName);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(10, 10, 10, 10)]
    [InlineData(80, 5, 80, 5)]
    [InlineData(10, 1, 10, 1)]
    [InlineData(10, 0, 10, 0)]
    [InlineData(0, 10, 0, 10)]
    [InlineData(0, 0, 0, 0)]
    [InlineData(0, -1, 0, -1)]
    [InlineData(50, -1, 50, -1)]
    public void UpdateItem(int initialQuality, int initialSellIn, int expectedQuality, int expectedSellIn)
    {
        // Arrange
        var item = new Item
        {
            Name = "Sulfuras, Hand of Ragnaros",
            Quality = initialQuality,
            SellIn = initialSellIn
        };

        // Act
        _sut.UpdateItem(item);

        // Assert
        Assert.Equal(expectedQuality, item.Quality);
        Assert.Equal(expectedSellIn, item.SellIn);
    }
}