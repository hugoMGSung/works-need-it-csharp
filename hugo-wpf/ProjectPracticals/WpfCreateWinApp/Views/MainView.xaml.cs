using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfCreateWinApp.Views
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            var view = new SubView();

            switch (CboWindowStyle.SelectedIndex)
            {
                case 0:
                    view.WindowStyle = WindowStyle.None;
                    break;
                case 1:
                    view.WindowStyle = WindowStyle.SingleBorderWindow;
                    break;
                case 2:
                    view.WindowStyle = WindowStyle.ThreeDBorderWindow;
                    break;
                case 3:
                    view.WindowStyle = WindowStyle.ToolWindow;
                    break;
            };

            switch (CboStartLocation.SelectedIndex)
            {
                case 0:
                    view.WindowStartupLocation = WindowStartupLocation.Manual;
                    break;
                case 1:
                    view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    break;
                case 2:
                    view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    break;
            };

            view.Owner = this;

            switch (CboModalType.SelectedIndex)
            {
                case 0:
                    view.ShowDialog();
                    break;
                case 1:
                    view.Show();
                    break;
            }
        }
    }
}
