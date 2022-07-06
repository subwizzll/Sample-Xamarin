using MvvmCross.Commands;
using MvvmCross.Navigation;
using Sample.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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

        IMvxAsyncCommand _getTaxRateCommand;
        public IMvxAsyncCommand GetTaxRateCommand => _getTaxRateCommand ??= new MvxAsyncCommand(async () =>
        {
            var taxRate = await _taxService.GetTaxRate("28704");
            Debug.WriteLine(taxRate.Rate.StateRate);
        });
    }
}
