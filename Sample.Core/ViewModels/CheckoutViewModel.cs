using System;
using System.Threading.Tasks;
using Sample.Core.Models.TaxCalcStore;
using Sample.Core.Service;
using Sample.Core.Services;
using Xamarin.Forms;

namespace Sample.Core.ViewModels
{
    public class CheckoutViewModel : BaseViewModel
    {
        readonly ICartService _cartService;
        readonly ITaxService _taxService;

        public Cart Cart => _cartService.Cart;

        public string ShippingLabel => this["ShippingLabel"];
        public string ShippingValueLabel => _cartService.Cart.Shipping > 0 
            ? _cartService.Cart.Shipping.ToString("C2")
            : this["ShippingValueLabel"];

        public string TaxLabel => string.Format(this["TaxLabel"], _cartService.Cart.TaxRate);
        public string TotalLabel => this["TotalLabel"];
        
        public CheckoutViewModel(ICartService cartService, ITaxService taxService)
            => (_cartService, _taxService) = (cartService, taxService);

        public override async void ViewAppearing()
        {
            base.ViewAppearing();
            await LoadOrderSummary();
        }
        
        async Task LoadOrderSummary()
        {
            var order = await _cartService.CreateOrder();
            var taxResponse = await _taxService.CalculateTaxes(order);
            var rateResponse = await _taxService.GetTaxRate(order.ToZip);
            
            if (taxResponse == null || rateResponse == null)
            {
                Application.Current.MainPage
                    .DisplayAlert(this["TaxError"], this["TaxErrorMessage"], this["OkText"])
                    .ContinueWith(BackCommand.Execute);
                return;
            }

            var taxAmount = taxResponse.Tax.AmountToCollect;
            var taxRate = rateResponse.Rate.CombinedRate;
            await _cartService.SetTaxRate(Double.Parse(taxRate));
            await _cartService.SetTaxAmount(taxAmount);
            RaisePropertyChanged(nameof(Cart));
            RaisePropertyChanged(nameof(TaxLabel));
            TaxJarRequestSucceeded = true;
        }

        bool _taxJarRequestSucceeded;
        public bool TaxJarRequestSucceeded
        {
            get => _taxJarRequestSucceeded;
            set => SetProperty(ref _taxJarRequestSucceeded, value);
        }
    }
}
