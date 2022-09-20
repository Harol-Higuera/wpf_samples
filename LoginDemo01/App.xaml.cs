using LoginDemo01.Views;
using Prism.Ioc;
using System.Windows;

namespace LoginDemo01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void OnInitialized()
        {
            var login = Container.Resolve<Login>();
            var result = login.ShowDialog();

            // result.Value becuause result is OPTIONAL
            //
            if (result.Value == true)
            {
                // Initialize this application if the User Logs in
                // 
                base.OnInitialized();
            }
            else { 
                // Kill this application
                //
                Application.Current.Shutdown();
            }
            
        }
    }
}
