using MvvmCross.Commands;
using Sample.Core.Models.TaxCalcStore;
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

        public IMvxAsyncCommand<LineItemDetail> AddToCartCommand
        {
            get => (IMvxAsyncCommand<LineItemDetail>)GetValue(AddToCartCommandProperty);
            set => SetValue(AddToCartCommandProperty, value);
        }

        public static readonly BindableProperty AddToCartCommandProperty = BindableProperty.CreateAttached(
            propertyName: nameof(AddToCartCommand),
            returnType: typeof(IMvxAsyncCommand<LineItemDetail>),
            declaringType: typeof(ShopFrame),
            defaultValue: null);

        public LineItemDetail AddToCartCommandParameter
        {
            get => (LineItemDetail)GetValue(AddToCartCommandParameterProperty);
            set => SetValue(AddToCartCommandParameterProperty, value);
        }

        public readonly BindableProperty AddToCartCommandParameterProperty = BindableProperty.CreateAttached(
            propertyName: nameof(AddToCartCommandParameter),
            returnType: typeof(LineItemDetail),
            declaringType: typeof(ShopFrame),
            defaultValue: new LineItemDetail());

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == ItemProperty.PropertyName)
                AddToCartCommandParameter.Item = Item;
            else if (propertyName == QuantityProperty.PropertyName)
                AddToCartCommandParameter.Quantity = Quantity;
        }
    }
}