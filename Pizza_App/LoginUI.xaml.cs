using PizzaClasses;
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
    /// Логика взаимодействия для LoginUI.xaml
    /// </summary>
    public partial class LoginUI : Page
    {
        UserDao dao = new UserDao();
        DataValidation dataValidation = new DataValidation();
        public LoginUI()
        {
            InitializeComponent();
        }

        private void NextFormButton_Click(object sender, RoutedEventArgs e)
        {
            var textVerification = dataValidation.VerificationOfLengthOfString(UserIdTextBox.Text, PassWordTextBox.Password , x => MessageBox.Show(x));
            if(textVerification == true)
            {
                //creation of the user from the data that the user had entered
                var user = new User(UserIdTextBox.Text, PassWordTextBox.Password);

                if (CheckerAccountExist.IsChecked == false && CheckerUserAccount.IsChecked == true)
                {
                    var ifUserExist = dataValidation.VerificationUserAlreadyExist(user);
                    if (ifUserExist == false && dao.InsertToJsonFile(user))
                    {
                        var userPage = new UserUi(UserIdTextBox.Text);
                        var mainWindow = Application.Current.MainWindow as MainWindow;
                        mainWindow.HomeFrame.Content = null;
                        mainWindow.MainFrame.Content = userPage;
                    }
                    else
                        MessageBox.Show("This User Already Exist \n You can not create An Account ");
                }
                else if (CheckerUserAccount.IsChecked == true && CheckerAccountExist.IsChecked == true)
                {
                    if (dataValidation.VerificationUserAlreadyExist(user) == true)
                    {
                        var userPage = new UserUi(UserIdTextBox.Text);
                        var mainWindow = Application.Current.MainWindow as MainWindow;
                        MessageBox.Show("Welcome Back ");
                        mainWindow.HomeFrame.Content = null;
                        mainWindow.MainFrame.Content = userPage;
                    }
                    else
                    {
                        MessageBox.Show("Check Your Data !!");
                    }
                }
                else if (checkerAdministratorAccount.IsChecked == true)
                {
                    var testAdmin = dataValidation.VerificationAdministratorAccount(UserIdTextBox.Text, PassWordTextBox.Password);
                    if (testAdmin == true)
                    {
                        var adminPage = new AdministratorUi();
                        var mainWindow = Application.Current.MainWindow as MainWindow;
                        MessageBox.Show("Welcome Administrator ");
                        mainWindow.HomeFrame.Content = null;
                        mainWindow.MainFrame.Content = adminPage;
                    }
                    else
                        MessageBox.Show("Check Your Data !!");
                }
                else
                    MessageBox.Show("Check Your Data !!");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.HomeFrame.Content = null;
            mainWindow.MainFrame.Content = null;
        }
     
    }
}
