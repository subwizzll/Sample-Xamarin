using MvvmCross.Navigation;
using Sample.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.ViewModels
{
    public class SampleListViewModel : BaseViewModel
    {
        public SampleListViewModel(ILogService logService,
                                   ITextProviderService textProvider,
                                   IMvxNavigationService navigationService) : base(logService,
                                                                                   textProvider,
                                                                                   navigationService) { }
    }
}
