using MvvmCross.Commands;
using MvvmCross.Navigation;
using Sample.Core.Services;
using System.Diagnostics;
using System.Threading.Tasks;
using Sample.Core.Models;
using Sample.Core.Models.TaxCalcStore;
using Sample.Core.Service;

namespace Sample.Core.ViewModels
{
    public class StoreViewModel : BaseViewModel
    {
        readonly ICartService _cartService;
        public Item[] Items => Data.MockItemData.SampleItems;

        public Cart Cart => _cartService.Cart;

        public StoreViewModel(ICartService cartService) => _cartService = cartService;

        IMvxAsyncCommand _myCartCommand;
        public IMvxAsyncCommand MyCartCommand => _myCartCommand ??= new MvxAsyncCommand(async () =>
        {
            //await _navigationService.Navigate<MyCartViewModel>();
        });

        IMvxAsyncCommand<(Item item, int qty)> _addToCartCommand;
        public IMvxAsyncCommand<(Item item, int qty)> AddToCartCommand => _addToCartCommand ??= new MvxAsyncCommand<(Item item, int qty)>(async parameter =>
        {
            await Task.Run(() =>
            {
                for (var i = 0; i < parameter.qty; i++)
                {
                    _cartService.Cart.LineItems.Add(parameter.item);
                }
            });
        });
    }
}
