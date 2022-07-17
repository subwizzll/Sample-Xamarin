using MvvmCross.Commands;
using Sample.Core.Models;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class ShopFrame : ItemFrame
    {
        public ShopFrame() => InitializeComponent();

        public string QuantityLabel => this["QuantityLabel"];
        public string QuantityPlaceholder => this["QuantityPlaceholder"];
        public string AddToCart => this["AddToCart"];

        public int Quantity
        {
            get => (int)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }

        public static readonly BindableProperty QuantityProperty = BindableProperty.CreateAttached(
            propertyName: nameof(Quantity),
            returnType: typeof(int),
            declaringType: typeof(ShopFrame),
            defaultValue: 1);

        public IMvxAsyncCommand<(Item item, int qty)> AddToCartCommand
        {
            get => (IMvxAsyncCommand<(Item item, int qty)>)GetValue(AddToCartCommandProperty);
            set => SetValue(AddToCartCommandProperty, value);
        }

        public static readonly BindableProperty AddToCartCommandProperty = BindableProperty.CreateAttached(
            propertyName: nameof(AddToCartCommand),
            returnType: typeof(IMvxAsyncCommand<(Item item, int qty)>),
            declaringType: typeof(ShopFrame),
            defaultValue: null);

        public (Item item, int qty) AddToCartCommandParameter
        {
            get => ((Item item, int qty))GetValue(AddToCartCommandParameterProperty);
            set => SetValue(AddToCartCommandParameterProperty, value);
        }

        public readonly BindableProperty AddToCartCommandParameterProperty = BindableProperty.CreateAttached(
            propertyName: nameof(AddToCartCommandParameter),
            returnType: typeof((Item item, int qty)),
            declaringType: typeof(ShopFrame),
            defaultValue: null);

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == ItemProperty.PropertyName || propertyName == QuantityProperty.PropertyName)
                AddToCartCommandParameter = (Item, Quantity);
        }
    }
}