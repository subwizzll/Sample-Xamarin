using Sample.Core.Controls;
using Sample.iOS.Renderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BaseFrame), typeof(BaseFrameRenderer))]
namespace Sample.iOS.Renderers
{
    public class BaseFrameRenderer : FrameRenderer
    {
        public BaseFrameRenderer()
        {
            Layer.CornerRadius = 0;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);


            var frame = (BaseFrame)Element;
            if (frame == null)
                return;

            if (frame.BorderWidth > 0)
            {
                Layer.BorderColor = frame.BorderColor.ToCGColor();
                Layer.BorderWidth = frame.BorderWidth;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}