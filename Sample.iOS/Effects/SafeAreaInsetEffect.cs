using Sample.Core.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using static Sample.Core.Framework.Helpers;

[assembly: ResolutionGroupName (nameof(Sample))]
[assembly: ExportEffect(typeof(SafeAreaInsetEffect), nameof(SafeAreaInsetEffect))]
namespace Sample.Core.iOS.Effects
{
	internal class SafeAreaInsetEffect : PlatformEffect
	{
		Thickness _padding;
		dynamic _element;
		static UIEdgeInsets _insets;
		static bool _insetsSet;

		protected override void OnAttached()
		{
			if (Element is not VisualElement) 
				return;

			_element = Element;

			if (!DoesPropertyExist(_element, nameof(_element.Padding)))
				return;
			
			_padding = _element.Padding;

			if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
				ApplyInsets(ref _element);
			else
				_element.Padding = new Thickness(
					left: _padding.Left,
					top: _padding.Top + 20, 
					right: _padding.Right, 
					bottom: _padding.Bottom);
		}

		void ApplyInsets(ref dynamic _element)
		{
			if (!_insetsSet)
			{
				_insets = UIApplication.SharedApplication.Windows[0].SafeAreaInsets; // Can't use KeyWindow this early
				_insetsSet = true;
			}

			if (_insets.Top <= 0)
				return;

			_element.Padding = new Thickness(
				left: _padding.Left + _insets.Left,
				top: _padding.Top + _insets.Top,
				right: _padding.Right + _insets.Right,
				bottom: _padding.Bottom + _insets.Bottom);
		}

		protected override void OnDetached()
		{
			if (Element is not VisualElement) 
				return;

			_element = Element;
			
			_element.Padding = _padding;
		}
	}
}

