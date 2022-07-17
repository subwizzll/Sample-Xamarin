using MvvmCross;
using Sample.Core.Services;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public class BaseFrame : Frame
    {
        readonly ITextProviderService _textProvider;

        protected BaseFrame()
        {
            _textProvider = Mvx.IoCProvider.Resolve<ITextProviderService>();
            if(!IsSet(CornerRadiusProperty))
                CornerRadius = 0;
        }

        public virtual string this[string index] => GetText(GetType().Name, index);

        string GetText(string model, string key) => _textProvider.GetText(model, key);
        
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
            child.BindingContext = this;
        }

        public float BorderWidth
        {
            get => (float)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.CreateAttached(
            propertyName: nameof(BorderWidth),
            returnType: typeof(float),
            declaringType: typeof(BaseFrame),
            defaultValue: 0f);
    }
}
