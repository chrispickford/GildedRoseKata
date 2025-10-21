using GildedRoseKata;
using GildedRoseKata.ItemProcessors;

namespace GildedRoseTests.UnitTests.ItemProcessors;

public class AgedBrieItemProcessorTests
{
    private readonly AgedBrieItemProcessor _sut = new();

    [Theory]
    [InlineData("Aged Brie", true)]
    [InlineData("Aged Bree", false)]
    [InlineData(" Aged Brie", false)]
    [InlineData("Aged  Brie", false)]
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
    [InlineData(10, 10, 11, 9)]
    [InlineData(10, 1, 11, 0)]
    [InlineData(10, 0, 12, -1)]
    [InlineData(10, -8, 12, -9)]
    [InlineData(50, 10, 50, 9)]
    [InlineData(50, -8, 50, -9)]
    public void UpdateItem(int initialQuality, int initialSellIn, int expectedQuality, int expectedSellIn)
    {
        // Arrange
        var item = new Item
        {
            Name = "Aged Brie",
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