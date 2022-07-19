using MvvmCross.Forms.Views;
using Sample.Core.Framework.Effects;
using Sample.Core.ViewModels;

namespace Sample.Core.Views
{
   public partial class MyCartPage : MvxContentPage<MyCartViewModel>
   {
        public MyCartPage()
        { 
            InitializeComponent();
            Effects.Add(new SafeAreaInsetEffect());
        }
   }
}