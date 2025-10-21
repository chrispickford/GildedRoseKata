using GildedRoseKata;
using GildedRoseKata.ItemProcessors;

namespace GildedRoseTests.UnitTests.ItemProcessors;

public class BackstagePassItemProcessorTests
{
    private readonly BackstagePassItemProcessor _sut = new();

    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", true)]
    [InlineData("Backstage passes", false)]
    [InlineData(" Backstage passes to a TAFKAL80ETC concert", false)]
    [InlineData("Backstage passes to a concert", false)]
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
    [InlineData(10, 11, 11, 10)]
    [InlineData(10, 10, 12, 9)]
    [InlineData(10, 5, 13, 4)]
    [InlineData(10, 1, 13, 0)]
    [InlineData(10, 0, 0, -1)]
    [InlineData(50, 11, 50, 10)]
    [InlineData(50, 10, 50, 9)]
    public void UpdateItem(int initialQuality, int initialSellIn, int expectedQuality, int expectedSellIn)
    {
        // Arrange
        var item = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
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