using Sample.Core.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using static Sample.Core.Framework.Helpers;
using SafeAreaInsetEffect = Sample.Core.iOS.Effects.SafeAreaInsetEffect;

[assembly: ResolutionGroupName (nameof(Sample))]
[assembly: ExportEffect(typeof(SafeAreaInsetEffect), nameof(SafeAreaInsetEffect))]
namespace Sample.Core.iOS.Effects
{
	internal class SafeAreaInsetEffect : PlatformEffect
	{
		Thickness _padding;
		InsetType _insetType;
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
			_insetType = Core.Effects.SafeAreaInsetEffect.GetInsetType(Element);

			if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
				ApplyInsets(ref _element);
			else
				_element.Padding = new Thickness(
					left: _padding.Left,
					top: _padding.Top + (_insetType is InsetType.Top or InsetType.TopAndBottom ? 20 : 0), 
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
				top: _padding.Top + (_insetType is InsetType.Top or InsetType.TopAndBottom ? _insets.Top : 0),
				right: _padding.Right + _insets.Right,
				bottom: _padding.Bottom +  (_insetType is InsetType.Bottom or InsetType.TopAndBottom ? _insets.Bottom : 0));
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

