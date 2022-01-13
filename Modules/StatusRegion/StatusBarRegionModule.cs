using Infrastructure.Constants;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using StatusBarRegion.Views;

namespace StatusBarRegion
{

    public class StatusBarRegionModule : IModule
    {
        /// <summary><inheritdoc/></summary>
        /// <remarks>REQUIRED: This takes care of any special initialization logic when loading the module.</remarks>
        /// <param name="containerProvider">Container where servies are registered for dependency injection.</param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //IRegionManager tells a region what view it needs to load.
            var regionManager = containerProvider.Resolve<IRegionManager>();

            //When this module is loaded, we want it to immediately load the StatusBar view.
            //To do this we call the RequestNavigate method of our IRegionManager where
            //      param1 = Name of the region that should navigate
            //      param2 = Name of the view that should be loaded
            regionManager.RequestNavigate(RegionNames.SHELL_STATUS_REGION, ModuleNames.STATUS);
        }

        /// <summary><inheritdoc/></summary>
        /// <remarks>REQUIRED: This is where we tell Prism what views will be available in this particular module.</remarks>
        /// <param name="containerRegistry">Container where modules are registered.</param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //This registers the specified view so that it is accessible to the IRegionManager for navigation.
            containerRegistry.RegisterForNavigation<StatusBar>();
        }
    }
}
