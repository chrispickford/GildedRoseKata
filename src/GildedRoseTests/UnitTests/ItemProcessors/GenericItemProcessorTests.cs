using GildedRoseKata;
using GildedRoseKata.ItemProcessors;

namespace GildedRoseTests.UnitTests.ItemProcessors;

public class GenericItemProcessorTests
{
    private readonly GenericItemProcessor _sut = new();

    [Theory]
    [InlineData("+5 Dexterity Vest", true)]
    [InlineData("Elixir of the Mongoose", true)]
    [InlineData("KJDSFBSAOFNBDSKFESUGSDKJFGB", true)]
    [InlineData("", true)]
    [InlineData(" ", true)]
    public void CanHandleItem_ReturnsExpectedResult(string itemName, bool expectedResult)
    {
        // Act
        var result = _sut.CanHandleItem(itemName);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(10, 10, 9, 9)]
    [InlineData(5, 5, 4, 4)]
    [InlineData(10, 1, 9, 0)]
    [InlineData(10, 0, 8, -1)]
    [InlineData(0, 10, 0, 9)]
    [InlineData(0, 0, 0, -1)]
    public void UpdateItem(int initialQuality, int initialSellIn, int expectedQuality, int expectedSellIn)
    {
        // Arrange
        var item = new Item
        {
            Name = "+5 Dexterity Vest",
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