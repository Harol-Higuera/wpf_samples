using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Prism_Demo01.ViewModels
{
    public class ViewAViewModel : BindableBase
    {

        // PROPERTIES
        //
        // TODO:If we have a lot of properties, we might pull these out into a model object ro something.
        //
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                _firstName = value; 
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private DateTime? _lastUpdated;
        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set { _lastUpdated = value; }
        }

        // DELEGATE COMMAND:
        // To activate the update button status and execute it
        public DelegateCommand UpdateCommand { get; set; }

        // Initialize the Delegate Command called UpdateCommand
        // Subscibe FirstName and LastName to changes in the Delegate Command
        //
        public ViewAViewModel() {
            UpdateCommand = new DelegateCommand(Execute,CanExecute)
                .ObservesProperty(() => FirstName)
                .ObservesProperty(() => LastName);
        }

        private bool CanExecute() {
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName);
        }

        private void Execute() { 
            LastUpdated = DateTime.Now;
        }

        // NAVIGATION
        //


    }
}
