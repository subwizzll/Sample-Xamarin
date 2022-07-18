using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.Core.Models.TaxCalcStore;
using static Sample.Core.Framework.Extensions;

namespace Sample.Core.Services
{
    public interface ICartService
    {
        public Cart Cart { get; set; }
        public Task AddItem(Item item);
        public Task AddItems(LineItemDetail value);
        public Task<Item> GetItem(Item item);
        public Task<IEnumerable<LineItemDetail>> GetItems();
        public Task RemoveItem(Item item);
        public Task RemoveItems(LineItemDetail value);
        public Task Reset();
    }

    public class CartService : ICartService
    {
        public Cart Cart { get; set; } = new();
        
        public async Task AddItem(Item item)
            => Cart.Items.Add(item);

        public async Task AddItems(LineItemDetail value)
            => Cart.Items.AddRange(value.Item.Repeated(value.Quantity));

        public async Task<Item> GetItem(Item item)
            => throw new System.NotImplementedException();

        public async Task<IEnumerable<LineItemDetail>> GetItems() => Cart.LineItems;

        public async Task RemoveItem(Item item)
            => throw new System.NotImplementedException();

        public async Task RemoveItems(LineItemDetail value)
            => throw new System.NotImplementedException();

        public async Task Reset() 
            => Cart.Items.Clear();
    }
}