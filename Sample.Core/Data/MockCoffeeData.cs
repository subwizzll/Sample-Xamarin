using Sample.Core.Models;

namespace Sample.Core.Data
{
    public static class MockCoffeeData
    {
        public static Coffee[] SampleCoffees => new[]
        {
            new Coffee()
            {
                Image = "CoffeeBag"
            }
        };
    }
}