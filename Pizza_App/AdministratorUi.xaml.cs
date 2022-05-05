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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizza_App
{
    /// <summary>
    /// Логика взаимодействия для AdministratorUi.xaml
    /// </summary>
    public partial class AdministratorUi : Page
    {
        public AdministratorUi()
        {
            InitializeComponent();
        }

        public void ButtonClose_Click(object sender , RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
        public void FloatBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FloatBar.SelectedIndex == 1)
            {
                var window = Application.Current.MainWindow as MainWindow;
                window.StackPanelOrder.Visibility = Visibility.Hidden;
                FrameUser.Content = new HomeAdministratorUi();
            }
            else if (FloatBar.SelectedIndex == 2)
            {
                var window = Application.Current.MainWindow as MainWindow;
                window.StackPanelOrder.Visibility = Visibility.Hidden;
                FrameUser.Content = new ListOfOrder();
            }else if (FloatBar.SelectedIndex == 0)
            {
                var window = Application.Current.MainWindow as MainWindow;
                window.StackPanelOrder.Visibility = Visibility.Visible;
                FrameUser.Content = null;
            }
        }

        private void DeconnectionButton_Click(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow as MainWindow;
            window.MainFrame.Content = null;
        }
    }
}
