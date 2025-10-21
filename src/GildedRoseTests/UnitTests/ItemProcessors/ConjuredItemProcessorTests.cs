using GildedRoseKata;
using GildedRoseKata.ItemProcessors;

namespace GildedRoseTests.UnitTests.ItemProcessors;

public class ConjuredItemProcessorTests
{
    private readonly ConjuredItemProcessor _sut = new();

    [Theory]
    [InlineData("Conjured", true)]
    [InlineData("Conjured Mana Cake", true)]
    [InlineData("Conjured KJDSFBSAOFNBDSKFESUGSDKJFGB", true)]
    [InlineData("Mana Cake Conjured", false)]
    [InlineData("Mana Cake", false)]
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
    [InlineData(6, 3, 4, 2)]
    [InlineData(10, 10, 8, 9)]
    [InlineData(10, 1, 8, 0)]
    [InlineData(10, 0, 6, -1)]
    [InlineData(10, -8, 6, -9)]
    [InlineData(0, 10, 0, 9)]
    [InlineData(0, 0, 0, -1)]
    public void UpdateItem(int initialQuality, int initialSellIn, int expectedQuality, int expectedSellIn)
    {
        // Arrange
        var item = new Item
        {
            Name = "Conjured Mana Cake",
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