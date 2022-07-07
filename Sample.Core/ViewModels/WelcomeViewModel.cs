using MvvmCross.Commands;
using MvvmCross.Navigation;
using Sample.Core.Services;
using System.Diagnostics;
using Sample.Core.Models;
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

        TaxRateInfo _taxrate;
        public TaxRateInfo TaxRateInfo
        {
            get => _taxrate;
            set => SetProperty(ref _taxrate, value);
        }

        IMvxAsyncCommand _getTaxRateCommand;
        public IMvxAsyncCommand GetTaxRateCommand => _getTaxRateCommand ??= new MvxAsyncCommand(async () =>
        {
            var taxRateResponse = await _taxService.GetTaxRate("28704");
            TaxRateInfo = taxRateResponse.RateInfo;
            Debug.WriteLine(taxRateResponse.RateInfo.StateRate);
        });
    }
}
