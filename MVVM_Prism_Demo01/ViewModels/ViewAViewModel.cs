using MVVM_Prism_Demo01.Events;
using Prism.Commands;
using Prism.Events;
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
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private DateTime? _lastUpdated;
        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set { SetProperty(ref _lastUpdated, value); }
        }

        // DELEGATE COMMAND:
        // To activate the update button status and execute it
        public DelegateCommand UpdateCommand { get; set; }

        // Initialize the Delegate Command called UpdateCommand
        // Subscibe FirstName and LastName to changes in the Delegate Command
        //
        private bool CanExecute() {
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName);
        }

        private void Execute() { 
            LastUpdated = DateTime.Now;

            // Aggregator sends a result to whoever is listening to UpdateEvent
            //
            eventAggregator.GetEvent<UpdateEvent>().Publish(LastUpdated.ToString());
        }

        // CONSTRUCTOR: Taken cared of by Prism
        //
        //
        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            // 1. Initialize the Delegate Command to give functionallity to the 
            // User interface
            //
            UpdateCommand = new DelegateCommand(Execute, CanExecute)
                .ObservesProperty(() => FirstName)
                .ObservesProperty(() => LastName);

            // 2. Initialize the event aggregator
            this.eventAggregator = eventAggregator;
        }


        // SENDING MESSAGES TO ANOTHER SCREEN
        // 
        //
        private IEventAggregator eventAggregator { get; }

    }
}
