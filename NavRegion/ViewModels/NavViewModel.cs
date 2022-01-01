using Prism.Commands;
using Prism.Regions;
using Infrastructure.Constants;
using Infrastructure.Common;

namespace NavRegion.ViewModels
{
    public class NavViewModel : ViewModelBase, INavigator
    {
        public DelegateCommand NavigateProcessCommand { get; }
        public DelegateCommand NavigateConfigureCommand { get; }
        public DelegateCommand ExitCommand { get; }

        public NavViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateProcessCommand = new DelegateCommand(NavigationService.NavigateToProcess);
            NavigateConfigureCommand = new DelegateCommand(NavigationService.NavigateToConfigure);
            ExitCommand = new DelegateCommand(NavigationService.Exit);
        }
    }
}
