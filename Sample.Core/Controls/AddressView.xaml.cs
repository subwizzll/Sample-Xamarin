using MvvmCross.Commands;
using Sample.Core.Models.TaxCalcStore;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class AddressView : BaseContentView
    {
        public AddressView() => InitializeComponent();

        public string FormattedAddress => "Testing\nnew lines\nand stuff";

        public bool IsEditMode
        {
            get => (bool)GetValue(IsEditModeProperty);
            set => SetValue(IsEditModeProperty, value);
        }

        public static readonly BindableProperty IsEditModeProperty = BindableProperty.CreateAttached(
            propertyName: nameof(IsEditMode),
            returnType: typeof(bool),
            declaringType: typeof(CartItemView),
            defaultValue: false);
    }
}