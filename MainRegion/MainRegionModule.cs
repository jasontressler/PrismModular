using Infrastructure.Constants;
using MainRegion.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;



namespace MainRegion
{
    public class MainRegionModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate(RegionNames.SHELL_MAIN_REGION, ModuleNames.MAIN_SPLASH);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Splash>();
            containerRegistry.RegisterForNavigation<Configure>();
            containerRegistry.RegisterForNavigation<Process>();
        }
    }
}
