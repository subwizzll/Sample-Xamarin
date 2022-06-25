using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Localization;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class NavBar
    {
        public NavBar() => InitializeComponent();

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
            child.BindingContext = this;
        }

        public ImageSource NavigationIcon
        {
            get => (ImageSource)GetValue(NavigationIconProperty);
            set => SetValue(NavigationIconProperty, value);
        }

        public static readonly BindableProperty NavigationIconProperty = BindableProperty.Create(
          propertyName: nameof(NavigationIcon),
          returnType: typeof(ImageSource),
          declaringType: typeof(NavBar),
          defaultValue: null);

        public NavigationTypes NavigationState
        {
            get => (NavigationTypes)GetValue(NavigationStateProperty);
            set => SetValue(NavigationStateProperty, value);
        }

        public static readonly BindableProperty NavigationStateProperty = BindableProperty.Create(
          propertyName: nameof(NavigationState),
          returnType: typeof(NavigationTypes),
          declaringType: typeof(NavBar),
          defaultValue: NavigationTypes.None,
          propertyChanged: (b, o, n) =>
          {
              var navBar = (NavBar)b; 
              switch ((NavigationTypes)n)
              {
                  case NavigationTypes.Back:
                      navBar.NavigationIcon = "LeftArrow";
                      break;
                  case NavigationTypes.Close:
                      navBar.NavigationIcon = "CloseCross";
                      break;
                  default:
                      break;
              }
           });

        public IMvxAsyncCommand NavigationCommand
        {
            get => (IMvxAsyncCommand)GetValue(NavigationCommandProperty);
            set => SetValue(NavigationCommandProperty, value);
        }

        public static readonly BindableProperty NavigationCommandProperty = BindableProperty.Create(
            nameof(NavigationCommand),
            typeof(IMvxAsyncCommand),
            typeof(NavBar));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(NavBar),
            defaultValue: string.Empty);

        public ICommand QuickActionsCommand
        {
            get => (ICommand)GetValue(QuickActionsCommandProperty);
            set => SetValue(QuickActionsCommandProperty, value);
        }

        public static readonly BindableProperty QuickActionsCommandProperty = BindableProperty.Create(
            propertyName: nameof(QuickActionsCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(NavBar),
            defaultValue: null,
            propertyChanged: (b, o, n) =>
            {
                var header = (NavBar)b;
            });

        public bool QuickActionsIsVisible
        {
            get => (bool)GetValue(QuickActionsIsVisibleProperty);
            set => SetValue(QuickActionsIsVisibleProperty, value);
        }

        public static readonly BindableProperty QuickActionsIsVisibleProperty = BindableProperty.Create(
            propertyName: nameof(QuickActionsIsVisible),
            returnType: typeof(bool),
            declaringType: typeof(NavBar),
            defaultValue: true);

        public bool SafeAreaInsetEnabled
        {
            get => (bool)GetValue(SafeAreaInsetEnabledProperty);
            set => SetValue(SafeAreaInsetEnabledProperty, value);
        }

        public static readonly BindableProperty SafeAreaInsetEnabledProperty = BindableProperty.Create(
            propertyName: nameof(SafeAreaInsetEnabled),
            returnType: typeof(bool),
            declaringType: typeof(NavBar),
            defaultValue: true);

        public enum NavigationTypes
        {
            None,
            Back,
            Close
        }

        public enum RightIconState
        {
            None,
            Info
        }
    }
}