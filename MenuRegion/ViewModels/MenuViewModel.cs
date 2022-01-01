using Infrastructure.Common;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuRegion.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public DelegateCommand NavigateProcessCommand { get; }
        public DelegateCommand NavigateConfigureCommand { get; }

        public MenuViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateProcessCommand = new DelegateCommand(NavigationService.NavigateToProcess);
            NavigateConfigureCommand = new DelegateCommand(NavigationService.NavigateToConfigure);
        }
    }
}
