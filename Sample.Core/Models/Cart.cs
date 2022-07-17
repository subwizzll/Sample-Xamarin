using System.Collections.ObjectModel;

namespace Sample.Core.Models
{
    public class Cart
    {
        public ObservableCollection<Item> LineItems { get; set; } = new();
    }
}