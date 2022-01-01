using Infrastructure.Constants;
using Prism.Regions;
using System;

namespace Infrastructure.Common
{
    public interface INavigationService
    {
        public void NavigateToProcess();
        public void NavigateToConfigure();
        public void Exit();
    }

    public class NavigationService : INavigationService
    {
        private readonly IRegionManager _regionManager;

        public NavigationService(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void NavigateToConfigure() => _regionManager.RequestNavigate(RegionNames.SHELL_MAIN_REGION, ModuleNames.MAIN_CONFIGURE);

        public void NavigateToProcess() => _regionManager.RequestNavigate(RegionNames.SHELL_MAIN_REGION, ModuleNames.MAIN_PROCESS);

        public void Exit() => Environment.Exit(0);
    }
}
