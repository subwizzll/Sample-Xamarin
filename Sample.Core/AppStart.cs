using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Sample.Core.ViewModels;

namespace Sample.Core
{
    public class AppStart : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            RegisterAppStart<StoreViewModel>();
        }
    }
}
