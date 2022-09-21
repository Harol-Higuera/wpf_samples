using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace MVVM_Prism_Demo01.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        // PROPERTIES 
        //
        private string _title = "Super Prism Application!!!";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        // NAVIGATION BETWEEN THE TABS 
        //
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager) 
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            // Note: In production apps "ContentRegion" should not be a magic string
            //
            _regionManager.RequestNavigate("ContentRegion", uri);
        }
    }
}
