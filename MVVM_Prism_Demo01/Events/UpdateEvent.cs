using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Prism_Demo01.Events
{
    // Let`s define an event
    // Message type is a String
    public class UpdateEvent : PubSubEvent<string>
    {

    }
}
