using Desktop.Presentation.ViewModels;

using System.Threading.Tasks;

namespace Desktop.Presentation.Common.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : NavigationTargetViewModel;
        Task NavigateToAsync<TViewModel>( object parameter ) where TViewModel : NavigationTargetViewModel;
        Task InitializeAsync();
    }
}
