using MVVMDialogs.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDialogs
{

    public interface IDialogService {
        void ShowDialog();
    }

    class DialogService : IDialogService
    {
        public void ShowDialog()
        {
            var dialog = new DialogWindow();
            // Not to be confused. The following ShowDialog is from the Window component.
            dialog.ShowDialog();
        }
    }
}
