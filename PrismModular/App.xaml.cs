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
        /// <summary><inheritdoc/></summary>
        /// <remarks>REQUIRED: Use this to create your shell window instead of StartupUri in your App.xaml</remarks>
        protected override Window CreateShell()
        {
            var w = Container.Resolve<Shell>();
            return (Window)w;
        }

        /// <summary><inheritdoc/></summary>
        /// <remarks>REQUIRED: You must override this method to include all the modules your application will use so it can start loading them up.</remarks>
        /// <param name="moduleCatalog">Container where modules are registered.</param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MenuRegionModule>();
            moduleCatalog.AddModule<NavRegionModule>();
            moduleCatalog.AddModule<StatusBarRegionModule>();
            moduleCatalog.AddModule<MainRegionModule>();
        }

        /// <summary><inheritdoc/></summary>
        /// <remarks>OPTIONAL: You can override this method to register services for dependency injection.</remarks>
        /// <param name="containerRegistry">Container where servies are registered for dependency injection.</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<INavigationService, NavigationService>();
        }

        /// <summary><inheritdoc/></summary>
        /// <remarks>OPTIONAL: You can override this method to customize how Prism handles autowiring ViewModels.</remarks>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            #region Explicity bind View to ViewModel
            /* 
             * This is useful when you deviate from the default naming convention.
             * Default convention is:
             *    - A view name "X" should be in namespace "Views" (ProjectName.Views.X)
             *    - The associated view model should be called "XViewModel" and be in namespace "ViewModels" (ProjectName.ViewModels.XViewModel)
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

    }
}
