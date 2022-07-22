using System.ComponentModel;
using MvvmCross.Forms.Views;
using Sample.Core.ViewModels;

namespace Sample.Core.Views
{
   public partial class MyCartPage : MvxContentPage<MyCartViewModel>
   {
        public MyCartPage() => InitializeComponent();
        //
        // void AddressViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        // {
        //     var propertyName = e.PropertyName;
        //     if (propertyName.Equals(HeightProperty.PropertyName))
        //         ViewModel.RaisePropertyChanged(nameof(ViewModel.ReadyForCheckout));
        // }
   }
}