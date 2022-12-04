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

namespace Bank
{
    /// <summary>
    /// Main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        /// <summary>
        /// Construct of MainWindow. Create connection to DB.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        /// <summary>
        /// Show CreateNewAccountWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateNewAccountWindow createNewAccountWindow = new CreateNewAccountWindow();
            createNewAccountWindow.Show();
        }
        /// <summary>
        /// Show AddMoneyWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddMoneyWindow addMoneyWindow = new AddMoneyWindow();
            addMoneyWindow.Show();
        }

        /// <summary>
        /// Show TakeMoneyWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Take_Click(object sender, RoutedEventArgs e)
        {
            TakeMoneyWindow takeMoneyWindow = new TakeMoneyWindow();
            takeMoneyWindow.Show();
        }

        /// <summary>
        /// Show DeleteAccountWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteAccountWindow deleteAccountWindow = new DeleteAccountWindow();
            deleteAccountWindow.Show();
        }

        /// <summary>
        /// Show ShowAccountsWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            ShowAccountsWindow showAccounts = new ShowAccountsWindow();
            showAccounts.Show();
        }

        /// <summary>
        /// Close application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            db.Dispose();
            Application.Current.Shutdown();
        }
    }
}
