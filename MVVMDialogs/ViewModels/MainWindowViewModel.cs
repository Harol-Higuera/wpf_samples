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
            // 1. This way shows the dialog based on the Dialog Name

            //_dialogService.ShowDialog("NotificationUserControl", result => {
            //    var test = result;
            //});

            // 2. Tjis way shows the dialog based on the ViewModel Type
            _dialogService.ShowDialog<NotificationUserControlViewModel> (result => {
                var test = result;
            });
        }
    }
}
