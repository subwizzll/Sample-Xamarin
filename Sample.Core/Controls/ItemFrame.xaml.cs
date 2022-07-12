using Sample.Core.Models;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class ItemFrame : BaseFrame
    {
        public ItemFrame() => InitializeComponent();

        public Item Item
        {
            get => (Item)GetValue(ItemProperty);
            set => SetValue(ItemProperty, value);
        }

        public static readonly BindableProperty ItemProperty = BindableProperty.CreateAttached(
            propertyName: nameof(Item),
            returnType: typeof(Item),
            declaringType: typeof(ItemFrame),
            defaultValue: null);

        public View AuxiliaryDetailContent
        {
            get => (View)GetValue(AuxiliaryDetailContentProperty);
            set => SetValue(AuxiliaryDetailContentProperty, value);
        }

        public static readonly BindableProperty AuxiliaryDetailContentProperty = BindableProperty.CreateAttached(
            propertyName: nameof(AuxiliaryDetailContent),
            returnType: typeof(View),
            declaringType: typeof(ItemFrame),
            defaultValue: null);

        public View AuxiliaryActionContent
        {
            get => (View)GetValue(AuxiliaryActionContentProperty);
            set => SetValue(AuxiliaryActionContentProperty, value);
        }

        public static readonly BindableProperty AuxiliaryActionContentProperty = BindableProperty.CreateAttached(
            propertyName: nameof(AuxiliaryActionContent),
            returnType: typeof(View),
            declaringType: typeof(ItemFrame),
            defaultValue: null);
    }
}