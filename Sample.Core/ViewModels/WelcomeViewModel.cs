using MvvmCross.Commands;
using MvvmCross.Navigation;
using Sample.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public WelcomeViewModel(ILogService logService,
                                ITextProviderService textProvider,
                                IMvxNavigationService navigationService) : base(logService, 
                                                                                textProvider, 
                                                                                navigationService) { }

        IMvxAsyncCommand _goToSampleListView;
        public virtual IMvxAsyncCommand GoToSampleListView => _goToSampleListView ??= new MvxAsyncCommand(async () =>
        {
            await _navigationService.Navigate<SampleListViewModel>();
        });
    }
}
