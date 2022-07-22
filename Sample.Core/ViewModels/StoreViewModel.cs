using System.Collections.Generic;
using MvvmCross.Commands;
using Sample.Core.Data;
using Sample.Core.Services;
using Sample.Core.Models.TaxCalcStore;

namespace Sample.Core.ViewModels
{
    public class StoreViewModel : BaseViewModel
    {
        readonly ICartService _cartService;
        
        public IEnumerable<Item> Items => MockItemData.MockItems;

        public Cart Cart => _cartService.Cart;

        public StoreViewModel(ICartService cartService) 
            => _cartService = cartService;

        IMvxAsyncCommand _myCartCommand;
        public IMvxAsyncCommand MyCartCommand => _myCartCommand ??= new MvxAsyncCommand(async () 
            => await _navigationService.Navigate<MyCartViewModel>());

        IMvxAsyncCommand<LineItemDetail> _addToCartCommand;
        public IMvxAsyncCommand<LineItemDetail> AddToCartCommand => _addToCartCommand ??= new MvxAsyncCommand<LineItemDetail>(async parameter =>
        {
            if (parameter.Quantity < 1)
                return;
            await _cartService.AddItems(parameter);
        });
    }
}
