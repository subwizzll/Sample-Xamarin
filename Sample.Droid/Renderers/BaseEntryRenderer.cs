using Android.Content;
using Sample.Core.Controls;
using Sample.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(BaseEntryRenderer), new[] { typeof(BaseVisual) })]
namespace Sample.Droid.Renderers
{
    public class BaseEntryRenderer : EntryRenderer
    {
        public BaseEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null) 
                return;
            
            Control.Gravity = Android.Views.GravityFlags.CenterVertical | Android.Views.GravityFlags.Left;
            Control.Background = null;
            Control.SetPadding(0, 0, 0, 0);
        }
    }
}