using Prism.Commands;

namespace Infrastructure.Common
{
    public interface INavigator
    {
        public DelegateCommand NavigateConfigureCommand { get; }
        public DelegateCommand NavigateProcessCommand { get; }
        public DelegateCommand ExitCommand { get; }

    }
}
