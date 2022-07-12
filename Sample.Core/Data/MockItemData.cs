using Sample.Core.Models;

namespace Sample.Core.Data
{
    public static class MockItemData
    {
        public static Item[] SampleItems => new[]
        {
            new Item
            {
                Image = "CoffeeBag",
                Name = "Tasty Coffee",
                Description = "The best coffee in town!",
                Price = 1.99
            }
        };
    }
}