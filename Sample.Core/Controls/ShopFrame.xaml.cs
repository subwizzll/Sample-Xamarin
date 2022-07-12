using MvvmCross.Commands;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class ShopFrame : ItemFrame
    {
        public ShopFrame() => InitializeComponent();

        public int Quantity
        {
            get => (int)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }

        public static readonly BindableProperty QuantityProperty = BindableProperty.CreateAttached(
            propertyName: nameof(Quantity),
            returnType: typeof(int),
            declaringType: typeof(ShopFrame),
            defaultValue: null);

        public IMvxAsyncCommand AddToCartCommand
        {
            get => (IMvxAsyncCommand)GetValue(AddToCartCommandProperty);
            set => SetValue(AddToCartCommandProperty, value);
        }

        public static readonly BindableProperty AddToCartCommandProperty = BindableProperty.CreateAttached(
            propertyName: nameof(AddToCartCommand),
            returnType: typeof(IMvxAsyncCommand),
            declaringType: typeof(ShopFrame),
            defaultValue: null);
    }
}