using Prism.Commands;
using Prism.Mvvm;
using System;

namespace CloseWindowFromViewModel.ViewModels
{
    public class MainWindowViewModel : BindableBase, ICloseWindow
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }

        /// <summary>
        ///  Declaration of the Command invoked by the Close Window Button
        /// </summary>
        private DelegateCommand _closeCommand;

        public DelegateCommand CloseCommand => 
            _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));

        public Action Close { get; set; }



        void CloseWindow()
        {
            Close?.Invoke();
        }

        public bool canClose()
        {
            // This is just an example, but this flag can be the result of any]
            // logic in this View Model
            //
            return true;
        }
    }

    interface ICloseWindow
    { 
        Action Close { get; set; }

        bool canClose();
    }
}
