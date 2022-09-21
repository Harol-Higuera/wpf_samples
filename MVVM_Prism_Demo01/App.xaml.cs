using MVVM_Prism_Demo01.Views;
using Prism.Ioc;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows;

namespace MVVM_Prism_Demo01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {

       
        protected override Window CreateShell()
        {
            // Set the firs Window that should be on the screen
            //
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register objects for navigation.
            //
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
        }
    }
}
