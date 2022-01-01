using Prism.Commands;
using Prism.Regions;
using Infrastructure.Constants;
using Infrastructure.Common;

namespace PrismModular.ViewModels
{
    public class NavRegionViewModel : ViewModelBase
    {
        public DelegateCommand NavigateProcessCommand { get; } 
        public DelegateCommand NavigateConfigureCommand { get; }

        public string Process => "Process";

        public NavRegionViewModel(IRegionManager regionManager) : base(regionManager)
        {
            NavigateProcessCommand = new DelegateCommand(NavigateToProcess);
            NavigateConfigureCommand = new DelegateCommand(NavigateToConfigure);
        }

        private void NavigateToProcess() => RegionManager.RequestNavigate(RegionNames.SHELL_MAIN_REGION, "Process");

        private void NavigateToConfigure() => RegionManager.RequestNavigate(RegionNames.SHELL_MAIN_REGION, "Configure");
    }
}
