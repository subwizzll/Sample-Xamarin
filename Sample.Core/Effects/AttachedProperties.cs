using Xamarin.Forms;

namespace Sample.Core.Effects
{
    public static class AttachedProperties
    {
        public static decimal GetBorderWidth(BindableObject view) => (decimal)view.GetValue(BorderWidthProperty);
        public static void SetBorderWidth(BindableObject view, decimal value) => view.SetValue(BorderWidthProperty, value);

        public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.CreateAttached("BorderWidth", typeof(decimal), typeof(AttachedProperties), 0);
    }
}
