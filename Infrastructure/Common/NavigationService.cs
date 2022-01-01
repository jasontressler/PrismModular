using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Constants;

namespace Infrastructure.Common
{
    public interface INavigationService
    {
        public void NavigateToProcess();
        public void NavigateToConfigure();
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
    }
}
