using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public class BaseFrame : Frame
    {
        public BaseFrame()
        {
            if(!IsSet(CornerRadiusProperty))
                CornerRadius = 0;
        }
        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.CreateAttached(propertyName: nameof(BorderWidth),
                                                                                                      returnType: typeof(float),
                                                                                                      declaringType: typeof(BaseFrame),
                                                                                                      defaultValue: (float)0);
    }
}
