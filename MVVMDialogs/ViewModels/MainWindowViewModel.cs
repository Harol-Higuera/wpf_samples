using Prism.Commands;
using Prism.Mvvm;

namespace MVVMDialogs.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        // In a production application, this service is injected into the constructor
        //
        IDialogService _dialogService = new DialogService();

        private DelegateCommand _showDialog;

        public DelegateCommand ShowDialog => 
            _showDialog ?? (_showDialog = new DelegateCommand(ExecuteShowDialog));

        void ExecuteShowDialog()
        {
            _dialogService.ShowDialog();  
        }
    }
}
