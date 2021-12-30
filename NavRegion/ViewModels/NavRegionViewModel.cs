using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;

namespace PrismModular.ViewModels
{
    public class NavRegionViewModel : BindableBase
    {
        public string Button1_Text => "Configure";
        public string Button2_Text => "Process";
        public string Button3_Text => "Exit";

        public DelegateCommand Button1_Command => null;
        public DelegateCommand Button2_Command => null;
        public DelegateCommand Button3_Command => null;
    }
}
