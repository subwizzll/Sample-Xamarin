﻿using System.Collections.Generic;
using System.Linq;
using MvvmCross;
using MvvmCross.Commands;
using Sample.Core.Services;
using Sample.Core.Models.TaxCalcStore;
using Xamarin.Forms;

namespace Sample.Core.ViewModels
{
    public class MyCartViewModel : BaseViewModel
    {
        readonly ICartService _cartService;

        public Cart Cart => _cartService.Cart;

        public IEnumerable<LineItemDetail> Items { get; set; }

        public string EmptyCartLabel => this["EmptyCartLabel"];
        public string CheckoutButton 
            => string.Format(this["CheckoutButton"], Cart.Items.Count);

        public bool ReadyForCheckout => Cart.Items.Count > 0;

        public MyCartViewModel(ICartService cartService)
            => _cartService = cartService;

        public override async void ViewAppearing()
            => Items = await _cartService.GetItems();

        // IMvxAsyncCommand _checkOutCommand;
        // public IMvxAsyncCommand CheckOutCommand => _checkOutCommand ??= new MvxAsyncCommand(async ()
        //     => await _navigationService.Navigate<CheckOutViewModel>());

        IMvxAsyncCommand<LineItemDetail> _updateCartCommand;
        public IMvxAsyncCommand<LineItemDetail> UpdateCartCommand => _updateCartCommand ??= new MvxAsyncCommand<LineItemDetail>(async parameter =>
        {
            await _cartService.UpdateItems(parameter);
            RaisePropertyChanged(nameof(ReadyForCheckout));
            RaisePropertyChanged(nameof(CheckoutButton));
        });
        
        IMvxAsyncCommand<LineItemDetail> _removeFromCartCommand;
        public IMvxAsyncCommand<LineItemDetail> RemoveFromCartCommand => _removeFromCartCommand ??= new MvxAsyncCommand<LineItemDetail>(async parameter =>
        {
            await _cartService.RemoveItems(parameter);
            RaisePropertyChanged(nameof(ReadyForCheckout));
            RaisePropertyChanged(nameof(CheckoutButton));
        });
    }
    
    public class MyCartTemplateSelector : DataTemplateSelector
    {
        readonly ICartService _cartService = Mvx.IoCProvider.Resolve<ICartService>();
        public DataTemplate NormalTemplate { get; set; }
        public DataTemplate LastItemTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate (object item, BindableObject container)
        {
            var lastItem = _cartService.Cart.LineItems.LastOrDefault();
            return lastItem.Equals(item) ? LastItemTemplate : NormalTemplate;
        }
    }
}