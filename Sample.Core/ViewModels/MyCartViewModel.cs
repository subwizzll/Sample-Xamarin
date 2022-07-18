using System.Collections.Generic;
using MvvmCross.Commands;
using Sample.Core.Services;
using Sample.Core.Models.TaxCalcStore;

namespace Sample.Core.ViewModels
{
    public class MyCartViewModel : BaseViewModel
    {
        readonly ICartService _cartService;

        public Cart Cart => _cartService.Cart;

        public IEnumerable<LineItemDetail> Items { get; set; }

        public MyCartViewModel(ICartService cartService) => _cartService = cartService;

        public override async void ViewAppearing()
        {
            base.ViewAppearing();
            Items = await _cartService.GetItems();
        }

        IMvxAsyncCommand _myCartCommand;
        public IMvxAsyncCommand MyCartCommand => _myCartCommand ??= new MvxAsyncCommand(async () =>
        {
            await _navigationService.Navigate<MyCartViewModel>();
        });

        IMvxAsyncCommand<LineItemDetail> _removeFromCartCommand;
        public IMvxAsyncCommand<LineItemDetail> RemoveFromCartCommand => _removeFromCartCommand ??= new MvxAsyncCommand<LineItemDetail>(async parameter =>
        {
            if (parameter.Quantity > 1)
                await _cartService.RemoveItems(parameter);
            else
                await _cartService.RemoveItem(parameter.Item);
        });
    }
}