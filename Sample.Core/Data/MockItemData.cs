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
                Price = 15.99
            },
            new Item
            {
                Image = "MatchaBag",
                Name = "Love Matcha Tea",
                Description = "Finest grade organic japanese matcha.",
                Price = 39.99
            },
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