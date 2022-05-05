using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pizza_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private bool allowNavigation = false;
        private NavigatingCancelEventArgs navArgs = null;
        private Duration duration = new Duration(TimeSpan.FromSeconds(1));
        private double oldHeigth = 0;
        private void MainFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (Content != null && !allowNavigation)
            {
                e.Cancel = true;
                navArgs = e;
                oldHeigth = MainFrame.ActualWidth;
                var animation = new DoubleAnimation();
                animation.From = MainFrame.ActualWidth;
                animation.To = 0;
                animation.Duration = duration;
                animation.Completed += SlideCompleted;
                //DoubleAnimation animationfade = new DoubleAnimation();
                //animationfade.From = 0;
                //animationfade.To = 1;
                //animationfade.Duration = duration;
                //animationfade.Completed += SlideCompletedfade;
                MainFrame.BeginAnimation(WidthProperty, animation);
                //MainFrame.BeginAnimation(OpacityProperty, animationfade);
            }
            allowNavigation = false;
        }
        //private void SlideCompletedfade(object sender, EventArgs e)
        //{
        //    allowNavigation = true;
        //    switch (navArgs.NavigationMode)
        //    {
        //        case NavigationMode.New:
        //            if (navArgs.Uri == null)
        //                MainFrame.Navigate(navArgs.Content);
        //            else
        //                MainFrame.Navigate(navArgs.Uri);
        //            break;
        //        case NavigationMode.Back:
        //            MainFrame.GoBack();
        //            break;
        //        case NavigationMode.Forward:
        //            MainFrame.GoForward();
        //            break;
        //        case NavigationMode.Refresh:
        //            MainFrame.Refresh();
        //            break;
        //    }
        //    //Dispatcher.BeginInvoke(DispatcherPriority.Loaded, (ThreadStart)delegate ()
        //    //{
        //    //    DoubleAnimation animation = new DoubleAnimation();
        //    //    animation.From = 0;
        //    //    animation.To = 1;
        //    //    animation.Duration = duration;
        //    //    MainFrame.BeginAnimation(OpacityProperty, animation);
        //    //});
        //}
        private void SlideCompleted(object sender, EventArgs e)
        {
            allowNavigation = true;
            switch (navArgs.NavigationMode)
            {
                case NavigationMode.New:
                    if (navArgs.Uri == null)
                        MainFrame.Navigate(navArgs.Content);
                    else
                        MainFrame.Navigate(navArgs.Uri);
                    break;
                case NavigationMode.Back:
                    MainFrame.GoBack();
                    break;
                case NavigationMode.Forward:
                    MainFrame.GoForward();
                    break;
                case NavigationMode.Refresh:
                    MainFrame.Refresh();
                    break;
            }
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, (ThreadStart)delegate ()
            {
               var animation = new DoubleAnimation();
                animation.From = 0;
                animation.To = oldHeigth;
                animation.Duration = new Duration(TimeSpan.FromSeconds(1));
                MainFrame.BeginAnimation(WidthProperty, animation);
            });
        }
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LoginUI();
        }

        private void FloatBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FloatBar.SelectedIndex == 1)
            {
                StackPanelOrder.Visibility = Visibility.Hidden;
                HomeFrame.Content = new HomeVisistorUi();
            }
            else if (FloatBar.SelectedIndex == 0)
            {
                HomeFrame.Content = null;
                StackPanelOrder.Visibility = Visibility.Visible;
            }
              
            else if (FloatBar.SelectedIndex == 3)
                HomeFrame.Content = null;
        }

        private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Register First !");
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
