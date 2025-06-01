using System.Configuration;
using System.Data;
using System.Windows;
using WpfCreateWinApp.Views;

namespace WpfCreateWinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var view = new MainView();
            view.Show();
        }
    }

}
