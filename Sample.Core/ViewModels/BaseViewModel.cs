using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Sample.Core.Services;

namespace Sample.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        protected readonly ILogService _logService;
        protected readonly ITextProviderService _textProvider;
        protected readonly IMvxNavigationService _navigationService;

        IMvxAsyncCommand _backCommand;
        public virtual IMvxAsyncCommand BackCommand => _backCommand ??= new MvxAsyncCommand(async () =>
        {
            await _navigationService.Close(this);
        });

        public string this[string index] => _textProvider.GetText(GetType().Name, index);

        public virtual string GetText(string key) => GetText(GetType().Name.Replace("`1", ""), key);

        public virtual string GetText(string viewModel, string key) => _textProvider.GetText(viewModel, key);

        protected BaseViewModel(ILogService logService,
                                ITextProviderService textProvider,
                                IMvxNavigationService navigationService)
        {
            _logService = logService;
            _textProvider = textProvider;
            _navigationService = navigationService;
        }

        bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        bool _isBusy;

        protected BaseViewModel() { }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }

    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
    {
        protected BaseViewModel(ILogService logService,
                                ITextProviderService textProvider,
                                IMvxNavigationService navigationService) : base(logService, 
                                                                                textProvider, 
                                                                                navigationService) { }

        public abstract void Prepare(TParameter parameter);
    }

    public abstract class BaseViewModel<TParameter, TResult> : BaseViewModel, IMvxViewModel<TParameter, TResult>
    {
        protected BaseViewModel(ILogService logService,
                                ITextProviderService textProvider,
                                IMvxNavigationService navigationService) : base(logService,
                                                                                textProvider,
                                                                                navigationService) { }

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public abstract void Prepare(TParameter parameter);

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted &&
                !CloseCompletionSource.Task.IsFaulted)
            {
                CloseCompletionSource?.TrySetCanceled();
            }

            base.ViewDestroy(viewFinishing);
        }
    }
    public abstract class BaseViewModelResult<TResult> : BaseViewModel, IMvxViewModelResult<TResult>
    {
        protected BaseViewModelResult(ILogService logService,
                                      ITextProviderService textProvider,
                                      IMvxNavigationService navigationService) : base(logService,
                                                                                      textProvider,
                                                                                      navigationService) { }

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }
        public object Result { get; set; } = default(TResult);

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (CloseCompletionSource?.Task != null
                && !CloseCompletionSource.Task.IsCompleted
                && !CloseCompletionSource.Task.IsFaulted)
            {
                CloseCompletionSource?.TrySetCanceled();
            }

            base.ViewDestroy(viewFinishing);
        }
    }
}
