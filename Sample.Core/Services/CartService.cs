using System.Threading.Tasks;
using Sample.Core.Models.TaxCalcStore;
using static Sample.Core.Framework.Extensions;

namespace Sample.Core.Services
{
    public interface ICartService
    {
        public Cart Cart { get; set; }
        public Task AddItem(Item item);
        public Task AddItems((Item item, int qty) value);
        public Task RemoveItem(Item item);
        public Task RemoveItems((Item item, int qty) value);
        public Task Reset();
    }

    public class CartService : ICartService
    {
        public Cart Cart { get; set; } = new();
        
        public async Task AddItem(Item item)
            => Cart.Items.Add(item);

        public async Task AddItems((Item item, int qty) value)
            => Cart.Items.AddRange(value.item.Repeated(value.qty));

        public Task RemoveItem(Item item)
            => throw new System.NotImplementedException();

        public Task RemoveItems((Item item, int qty) value)
            => throw new System.NotImplementedException();

        public async Task Reset() 
            => Cart.Items.Clear();
    }
}