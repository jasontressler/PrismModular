using Infrastructure.Constants;
using NavRegion.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace NavRegion
{
    public class NavRegionModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate(RegionNames.SHELL_NAV_REGION, ModuleNames.NAV);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Nav>();
        }
    }
}
