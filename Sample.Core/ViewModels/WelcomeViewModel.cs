using MvvmCross.Commands;
using MvvmCross.Navigation;
using Sample.Core.Services;
using System.Diagnostics;
using System.Threading.Tasks;
using Sample.Core.Models;
using Sample.Core.Models.Orders;
using Sample.Core.Models.Rates;
using Sample.Core.Service;

namespace Sample.Core.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        readonly ITaxService _taxService;
        
        public WelcomeViewModel(ILogService logService,
                                ITextProviderService textProvider,
                                IMvxNavigationService navigationService,
                                ITaxService taxService) : base(logService,
                                                               textProvider,
                                                               navigationService)
        {
            _taxService = taxService;
        }

        public Item[] Items => Data.MockItemData.SampleItems;

        public Cart Cart { get; } = new();

        IMvxAsyncCommand<(Item item, int qty)> _addToCartCommand;
        public IMvxAsyncCommand<(Item item, int qty)> AddToCartCommand => _addToCartCommand ??= new MvxAsyncCommand<(Item item, int qty)>(async parameter =>
        {
            await Task.Run(() =>
            {
                for (var i = 0; i < parameter.qty; i++)
                {
                    Cart.LineItems.Add(parameter.item);
                }
            });
        });
        //
        // IMvxAsyncCommand _getTaxRateCommand;
        // public IMvxAsyncCommand GetTaxRateCommand => _getTaxRateCommand ??= new MvxAsyncCommand(async () =>
        // {
        //     var taxRateResponse = await _taxService.GetTaxRate("28704");
        //     Cart = taxRateResponse.Rate;
        //     Debug.WriteLine(taxRateResponse.Rate.StateRate);
        // });
        //
        // IMvxAsyncCommand _calculateTaxesCommand;
        // public IMvxAsyncCommand CalculateTaxesCommand => _calculateTaxesCommand ??= new MvxAsyncCommand(async () =>
        // {
        //     var order = new Order
        //     {
        //         FromCountry = "US",
        //         FromZip = "07001",
        //         FromState = "NJ",
        //         ToCountry = "US",
        //         ToZip = "07446",
        //         ToState = "NJ",
        //         Amount = 15,
        //         Shipping = 1.5
        //     };
        //     var taxesResponse = await _taxService.CalculateTaxes(order);
        //     Debug.WriteLine(taxesResponse.Tax.AmountToCollect);
        // });
    }
}
