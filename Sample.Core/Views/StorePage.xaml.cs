using MvvmCross.Forms.Views;
using Sample.Core.Effects;
using Sample.Core.ViewModels;

namespace Sample.Core.Views
{
   public partial class StorePage : MvxContentPage<StoreViewModel>
   {
        public StorePage()
        { 
            InitializeComponent();
            Effects.Add(new SafeAreaInsetEffect());
        }
   }
}