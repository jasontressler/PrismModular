using Prism.Modularity;
using Infrastructure.Constants;
using Prism.Ioc;
using Prism.Regions;

namespace StatusRegion
{
    public class StatusRegionModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate(RegionNames.SHELL_STATUS_REGION, ModuleNames.STATUS_REGION);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<StatusRegion>();
        }
    }
}
