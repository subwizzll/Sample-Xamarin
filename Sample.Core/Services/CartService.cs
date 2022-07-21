using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Sample.Core.Models.TaxCalcStore;
using Xamarin.CommunityToolkit.ObjectModel;
using static Sample.Core.Framework.Extensions;

namespace Sample.Core.Services
{
    public interface ICartService
    {
        public Cart Cart { get; set; }
        public Task UpdateLineItems();
        public Task UpdateItems(LineItemDetail value);
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

        public CartService() 
            => Cart.Items.CollectionChanged += CollectionChanged;

        async void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            => await UpdateLineItems();

        public async Task UpdateLineItems()
        {
            var distinctItems = Cart.Items.Distinct();
            var newLineItemDetails = new ObservableRangeCollection<LineItemDetail>();
            
            foreach (var item in distinctItems)
            {
                var count = Cart.Items.Count(x => x.Equals(item));
                if (count.IsPositive())
                    newLineItemDetails.Add(new LineItemDetail{Item = item, Quantity = count});
            }
            Cart.LineItems.ReplaceRange(newLineItemDetails);
        }

        public async Task UpdateItems(LineItemDetail value)
        {
            var currentQuantity = Cart.LineItems.First(x => x.Item.Equals(value.Item)).Quantity;
            var quantityDifference = currentQuantity - value.Quantity;
            var tempLineItems = new LineItemDetail{ Item = value.Item, Quantity = Math.Abs(quantityDifference) };
            
            if (quantityDifference.IsPositive())
                await RemoveItems(tempLineItems);
            else if (quantityDifference.IsNegative())
                await AddItems(tempLineItems);
        }

        public async Task AddItem(Item item)
            => Cart.Items.Add(item);

        public async Task AddItems(LineItemDetail value)
            => Cart.Items.AddRange(value.Item.Repeated(value.Quantity));

        public async Task RemoveItem(Item item)
            => Cart.Items.Remove(Cart.Items.First(x => x.Equals(item)));

        public async Task RemoveItems(LineItemDetail value)
            =>  Cart.Items.RemoveRange(value.Item.Repeated(value.Quantity));

        public async Task<Item> GetItem(Item item)
            => Cart.Items.First(x => x == item);

        public async Task<IEnumerable<LineItemDetail>> GetItems() 
            => Cart.LineItems;

        public async Task Reset() 
            => Cart.Items.Clear();
    }
}