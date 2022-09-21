using MVVMDialogs.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDialogs
{

    // In a production app the interface might go in a separate file
    public interface IDialogService {
        void ShowDialog(string name, Action<string> callback);
        void ShowDialog<TViewModel>(Action<string> callback);
    }

    class DialogService : IDialogService
    {
        static Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public static void RegisterDialog<TView, TViewModel>()
        { 
            _mappings.Add(typeof(TViewModel), typeof(TView));
        }


        public void ShowDialog(string name, Action<string> callback)
        {
            var type = Type.GetType($"MVVMDialogs.Dialogs.{name}");
            ShowDialogInternal(type, callback);
        }


        public void ShowDialog<TViewModel>(Action<string> callback)
        {
            var type = _mappings[typeof(TViewModel)];
            ShowDialogInternal(type, callback);
        }

        private static void ShowDialogInternal(Type type, Action<string> callback)
        {
            var dialog = new DialogWindow();


            // Set up the event handler so the ViewModel knows when the doalog is closed
            // Also can get some result from it.
            //
            EventHandler closeEventHandler = null;
            closeEventHandler = (s, e) =>
            {
                callback(dialog.DialogResult.ToString());
                dialog.Closed -= closeEventHandler;  // Here we remove the event handler (You know to clean up memory)
            };
            dialog.Closed += closeEventHandler; // Here we hook the event handler


            // LETS SET THE CONTENT OF THE DIALOG DYNAMICALLY
            //
            // The namespace where the Dialog classes are going to be
            // 
            dialog.Content = Activator.CreateInstance(type);

            // Not to be confused. The following ShowDialog is from the Window component.
            dialog.ShowDialog();
        }

    }
}
