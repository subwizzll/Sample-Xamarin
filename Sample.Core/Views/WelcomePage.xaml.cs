using MvvmCross.Forms.Views;
using Sample.Core.Effects;
using Sample.Core.ViewModels;

namespace Sample.Core.Views
{
   public partial class WelcomePage : MvxContentPage<WelcomeViewModel>
   {
        public WelcomePage()
        { 
            InitializeComponent();
            Effects.Add(new SafeAreaInsetEffect());
        }
   }
}