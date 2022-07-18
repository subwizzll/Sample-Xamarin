using Xamarin.CommunityToolkit.ObjectModel;

namespace Sample.Core.Models.TaxCalcStore
{
    public class Cart
    {
        public ObservableRangeCollection<Item> Items { get; set; } = new();

        public ObservableRangeCollection<LineItemDetail> LineItems { get; set; } = new();
    }
}