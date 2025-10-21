using GildedRoseKata;
using GildedRoseKata.ItemProcessors;

namespace GildedRoseTests.UnitTests;

public class ItemProcessorFactoryTests
{
    [Fact]
    public void GetItemProcessor_ReturnsNull_WhenNoProcessors()
    {
        // Arrange
        var processors = Enumerable.Empty<IItemProcessor>();
        var sut = new ItemProcessorFactory(processors);

        // Act
        var result = sut.GetItemProcessor("itemName");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetItemProcessor_ReturnsNull_WhenNoMatchingProcessors()
    {
        // Arrange
        IEnumerable<IItemProcessor> processors = [
            new TestItemProcessor(Guid.NewGuid().ToString()),
            new TestItemProcessor(Guid.NewGuid().ToString()),
            new TestItemProcessor(Guid.NewGuid().ToString())
        ];
        var sut = new ItemProcessorFactory(processors);

        // Act
        var result = sut.GetItemProcessor("itemName");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetItemProcessor_ReturnsProcessor_WhenMatchingProcessors()
    {
        // Arrange
        var itemName = "itemName";
        var expectedProcessor = new TestItemProcessor(itemName);
        IEnumerable<IItemProcessor> processors = [
            new TestItemProcessor(Guid.NewGuid().ToString()),
            new TestItemProcessor(Guid.NewGuid().ToString()),
            expectedProcessor
        ];
        var sut = new ItemProcessorFactory(processors);

        // Act
        var result = sut.GetItemProcessor(itemName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedProcessor, result);
    }

    [Fact]
    public void GetItemProcessor_ReturnsFirstProcessor_WhenManyMatchingProcessors()
    {
        // Arrange
        var itemName = "itemName";
        var expectedProcessor = new TestItemProcessor(itemName);
        IEnumerable<IItemProcessor> processors = [
            new TestItemProcessor(Guid.NewGuid().ToString()),
            new TestItemProcessor(Guid.NewGuid().ToString()),
            expectedProcessor,
            new TestItemProcessor(itemName)
        ];
        var sut = new ItemProcessorFactory(processors);

        // Act
        var result = sut.GetItemProcessor(itemName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedProcessor, result);
    }

    private class TestItemProcessor(string matchingItemName) : IItemProcessor
    {
        public bool CanHandleItem(string itemName) =>
            itemName.Equals(matchingItemName, StringComparison.Ordinal);

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}