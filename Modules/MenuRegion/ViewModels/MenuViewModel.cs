using Infrastructure.Common;
using Prism.Commands;

namespace MenuRegion.ViewModels
{
    public class MenuViewModel : ViewModelBase, INavigator
    {
        public DelegateCommand NavigateConfigureCommand { get; }

        public DelegateCommand NavigateProcessCommand { get; }

        public DelegateCommand ExitCommand { get; }


        public MenuViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateConfigureCommand = new DelegateCommand(navigationService.NavigateToConfigure);
            NavigateProcessCommand = new DelegateCommand(navigationService.NavigateToProcess);
            ExitCommand = new DelegateCommand(navigationService.Exit);
        }

    }
}
