﻿using MVVM_Prism_Demo01.Views;
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
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>("ViewA");
            containerRegistry.RegisterForNavigation<ViewB>("ViewB");
        }
    }
}