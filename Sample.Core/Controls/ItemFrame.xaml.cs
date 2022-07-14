using Sample.Core.Models;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class ItemFrame : BaseFrame
    {
        public ItemFrame() => InitializeComponent();
            
        public double PrimaryDetailWidth
        {
            get => (double)GetValue(PrimaryDetailWidthProperty);
            set => SetValue(PrimaryDetailWidthProperty, value);
        }

        public static readonly BindableProperty PrimaryDetailWidthProperty = BindableProperty.CreateAttached(
            propertyName: nameof(PrimaryDetailWidth),
            returnType: typeof(double),
            declaringType: typeof(ItemFrame),
            defaultValue: WidthRequestProperty.DefaultValue);
            
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
            defaultValue: null,
            propertyChanged: (b, o, n) =>
            {
                var itemFrame = b as ItemFrame;
                var widthValue = itemFrame.AuxiliaryDetailContent != null
                    ? 200
                    : PrimaryDetailWidthProperty.DefaultValue;
                itemFrame.SetValue(PrimaryDetailWidthProperty, widthValue);
            });

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