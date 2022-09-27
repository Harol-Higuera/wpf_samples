using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace INotificationDataErrorInfoDemo.ViewModels
{
    public class MainWindowViewModel : BindableBase, INotifyDataErrorInfo
    {
        private readonly ErrorsViewModel _errorsViewModel;
        public DelegateCommand CreateProductCommand { get; }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors => _errorsViewModel.HasErrors;


        private int _id;
        public int Id
        {
            get { return _id; }
            set  { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private int _price;
        public int Price
        {
            get { return _price; }
            set {
                SetProperty(ref _price, value);
                _errorsViewModel.ClearErrors(nameof(Price));
                if (_price > 50) 
                {
                    _errorsViewModel.AddError(nameof(Price), "Invalid price. The max product price is $50.00.");
                }
            }
        }

        // Constructor
        public MainWindowViewModel()
        {
            CreateProductCommand = new DelegateCommand(Execute);
            _errorsViewModel = new ErrorsViewModel();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

        }

        // Whenever there is an error change I want to invoke RaisePropertyChanged
        // So the button status changes accordingly
        //
        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            RaisePropertyChanged(nameof(CanCreate));
        }

        // The button property isEnabled is binded to this property so the 
        // Button activates anytime CanCreate is true.
        //
        public bool CanCreate => !HasErrors;

        private void Execute() {
            // TODO:(Execue something)
            MessageBox.Show("Way to go!!");
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }
    }
}
