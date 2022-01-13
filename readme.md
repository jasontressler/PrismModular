# Modules

Each of these projects is a WPF class library that will hold the **Views**, **ViewModels**, and **initialization logic** for loading the views into the Prism regions we will define later in our shell. Each of these projects, by default, should have:

 * At least one *View*
 * At least one corresponding *ViewModel*
 * One class implementing *IModule*

## View
Generally speaking, a view in this scenario should be of type *UserControl* since we will be embedding these into another window.
Default convention does not require (but permits) the name of the view to end with "View".

Your view should also be in the *Views* namespace. So if your view is called "MainMenu", your namespace should be *Views.MainMenu*. 

Aside from these specs, the only other thing to note is that the views should include the *prism* namespace (or whatever you want to name it) and set the **ViewModelLocator.AutoWireViewModel** property to *true* if you want Prism to automatically find and instantiate the appropriate view model for the view.

```xml
<UserControl x:Class="SampleProject.Views.MainMenu"
    ...
    xmlns:prism="http://prismlibrary.com/"
    prism:ViewModelLocator.AutoWireViewModel="True">
    
    ...

</UserControl>
```

## View Model
This is mostly just a standard view model with only a few caveats.

If you're rolling with auto wiring with your views, the view model should be the name of the view with "ViewModel" appended to the end.  It should also be in the *ViewModels* namespace so Prism can find it. So continuing from our example above, this view model would be called *ViewModels.MainMenuViewModel*. There are ways to customize the autowiring to use alternate criteria, but we'll discuss that later on.

Prism provides the **BindableBase** class that your view model can inherit from and provides a default implementation of the **INotifyPropertyChanged** interface.

Lastly, since we're using this view with navigation, we need to implement the **INavigationAware** interface. This just provides some extra events for when you navigate to or away from a view.

I wrapped these up in a **ViewModelBase** class to avoid implementing them manually in every view model. Don't worry about the **INavigationService** just yet; That can be omitted for now.

```cs
public class ViewModelBase : BindableBase, INavigationAware
    {
        protected INavigationService NavigationService { get; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
```
```cs
namespace MainRegion.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        public ConfigureViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
```

## IModule
Finally, this is the class that is responsible for telling the module what views it is responsible for loading. The naming doesn't necessarily matter here, but it needs to implement **IModule**, which comes with two methods:

 * **OnInitialized** - What happens when the module is loaded.
 * **RegisterTypes** - The views that the module is responsible for.

