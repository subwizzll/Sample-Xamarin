using Xamarin.CommunityToolkit.ObjectModel;

namespace Sample.Core.Models.TaxCalcStore
{
    public class Cart
    {
        ObservableRangeCollection<Item> _items = new();
        public ObservableRangeCollection<Item> Items
        {
            get => _items;
            set
            {
                Items = value;
                UpdateLineItems();
            }
        }

        public ObservableRangeCollection<LineItemDetail> LineItems { get; set; } = new();
        
        void UpdateLineItems()
        {
            throw new System.NotImplementedException();
        }
    }
}