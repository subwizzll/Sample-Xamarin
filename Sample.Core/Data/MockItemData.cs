using Sample.Core.Models.TaxCalcStore;

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
                Image = "MatchaChasen",
                Name = "Matcha Chasen",
                Description = "A bamboo matcha whisk, part of Chanoyu, a Japanese tea ceremony",
                Price = 10.99
            }
        };
    }
}