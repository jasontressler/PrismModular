using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using Prism.Mvvm;
using Prism.Modularity;
using MenuRegion;
using NavRegion;
using StatusRegion;

namespace PrismModular {
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
            //throw new NotImplementedException();
            //containerRegistry.Register<IService, Service>();
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
            moduleCatalog.AddModule<StatusRegionModule>();
        }
    }
}
