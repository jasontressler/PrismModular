using Infrastructure.Common;
using MainRegion;
using MenuRegion;
using NavRegion;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using StatusBarRegion;
using System.Windows;

namespace PrismModular
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<Shell>();
            return (Window)w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<INavigationService, NavigationService>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            #region Explicity bind View to ViewModel
            /* 
             * This is useful when you deviate from a naming convention.
             * This is also useful for speeding up your application because
             * the default autowiring uses resource-heavy reflection.
             * There are 4 ways to do this:
             */

            //Register ViewModel to View explicitly
            //ViewModelLocationProvider.Register(typeof(NavigationView).ToString(), typeof(NavigationViewModel));

            //Register ViewModel to View, shorthand
            //ViewModelLocationProvider.Register<NavigationView, NavigationViewModel>();

            //Register ViewModel to View with factory method
            //ViewModelLocationProvider.Register(typeof(NavigationView).ToString(), () => new NavigationViewModel());

            //Register ViewModel to View with factory method, shorthand
            //ViewModelLocationProvider.Register<NavigationView>(() => new NavigationViewModel());
            #endregion

            #region Custom Naming Convention
            //Change default naming convention for autowiring
            //    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            //    {
            //        var prefix = viewType.FullName.Replace(".Views.", ".temp.").Replace("View", "ViewModel").Replace(".temp.", ".ViewModels.");
            //        var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            //        var viewModelName = $"{prefix}, {viewAssemblyName}";
            //        return Type.GetType(viewModelName);
            //    });
            #endregion
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MenuRegionModule>();
            moduleCatalog.AddModule<NavRegionModule>();
            moduleCatalog.AddModule<StatusBarRegionModule>();
            moduleCatalog.AddModule<MainRegionModule>();
        }
    }
}
