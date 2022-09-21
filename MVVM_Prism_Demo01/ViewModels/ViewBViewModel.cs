using MVVM_Prism_Demo01.Events;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Prism_Demo01.ViewModels
{
    public class ViewBViewModel: BindableBase
    {
        // PROPERTIES
        //
        //
        private string _message = "View B";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        // CONSTRUCTOR
        //
        //
        public ViewBViewModel(IEventAggregator eventAggregator) {
            eventAggregator.GetEvent<UpdateEvent>().Subscribe(MessageReceiver);
        }

        // MESSAGE RECEIVERS (From other screens)
        //
        //
        private void MessageReceiver(string obj)
        {
            Message = obj;
        }
    }
}
