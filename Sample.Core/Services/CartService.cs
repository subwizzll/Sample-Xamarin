using System.Threading.Tasks;
using Sample.Core.Framework;
using Sample.Core.Models.TaxCalcStore;

namespace Sample.Core.Services
{
    public interface ICartService
    {
        public Cart Cart { get; set; }
        public Task AddItem(Item item);
        public Task AddItems((Item item, int qty) value);
        public Task Reset();
    }
    public class CartService : ICartService
    {
        public Cart Cart { get; set; } = new();
        public async Task AddItem(Item item) => Cart.LineItems.Add(item);
        public async Task AddItems((Item item, int qty) value) => value.item.Repeated(value.item, value.qty);
        public async Task Reset() => Cart.LineItems.Clear();
    }
}