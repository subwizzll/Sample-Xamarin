using MvvmCross.Commands;
using Sample.Core.Services;
using Sample.Core.Models.TaxCalcStore;

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
            await _navigationService.Navigate<MyCartViewModel>();
        });

        IMvxAsyncCommand<(Item item, int qty)> _addToCartCommand;
        public IMvxAsyncCommand<(Item item, int qty)> AddToCartCommand => _addToCartCommand ??= new MvxAsyncCommand<(Item item, int qty)>(async parameter =>
        {
            if (parameter.qty > 1)
                await _cartService.AddItems(parameter);
            else
                await _cartService.AddItem(parameter.item);
        });
    }
}
