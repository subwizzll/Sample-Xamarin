using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Sample.Core.Controls;
using System.ComponentModel;
using Android.Graphics;
using Sample.Droid.Renderers;

[assembly: ExportRenderer(typeof(BaseFrame), typeof(BaseFrameRenderer))]
namespace Sample.Droid.Renderers
{
    public class BaseFrameRenderer : FrameRenderer
    { 
        public BaseFrameRenderer(Context context) : base(context)
        {
            SetWillNotDraw(false);
        }

        protected override void OnDraw(Canvas canvas)
        {
            var frame = Element as BaseFrame;

            var my1stPaint = new Paint();
            var my2ndPaint = new Paint();
            var backgroundPaint = new Paint();

            my1stPaint.AntiAlias = true;
            my1stPaint.SetStyle(Paint.Style.Stroke);
            my1stPaint.StrokeWidth = frame.BorderWidth;
            my1stPaint.Color = frame.BorderColor.ToAndroid();

            my2ndPaint.AntiAlias = true;
            my2ndPaint.SetStyle(Paint.Style.Stroke);
            my2ndPaint.StrokeWidth = frame.BorderWidth;
            my2ndPaint.Color = frame.BackgroundColor.ToAndroid();

            backgroundPaint.SetStyle(Paint.Style.Stroke);
            backgroundPaint.StrokeWidth = 4;
            backgroundPaint.Color = frame.BackgroundColor.ToAndroid();

            Android.Graphics.Rect oldBounds = new Android.Graphics.Rect();
            canvas.GetClipBounds(oldBounds);

            RectF oldOutlineBounds = new RectF();
            oldOutlineBounds.Set(oldBounds);

            RectF myOutlineBounds = new RectF();
            myOutlineBounds.Set(oldBounds);
            myOutlineBounds.Top += (int)my2ndPaint.StrokeWidth / 2;
            myOutlineBounds.Bottom -= (int)my2ndPaint.StrokeWidth / 2;
            myOutlineBounds.Left += (int)my2ndPaint.StrokeWidth / 2;
            myOutlineBounds.Right -= (int)my2ndPaint.StrokeWidth / 2;

            //canvas.DrawRoundRect(oldOutlineBounds, 10, 10, backgroundPaint); //to "hide" old outline
            canvas.DrawRoundRect(myOutlineBounds, frame.CornerRadius, frame.CornerRadius, my1stPaint);
            //canvas.DrawRoundRect(myOutlineBounds, frame.CornerRadius, frame.CornerRadius, my2ndPaint);

            base.OnDraw(canvas);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == BaseFrame.BorderWidthProperty.PropertyName) //Tried with multiple of DrawRect properties.
                Invalidate(); // Force a call to OnDraw
        }
    }
}