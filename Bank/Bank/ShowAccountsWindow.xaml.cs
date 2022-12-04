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
using BankDB;

namespace Bank
{
    /// <summary>
    /// Show accounts information window
    /// </summary>
    public partial class ShowAccountsWindow : Window
    {
        ApplicationContext db;

        /// <summary>
        /// Construct of ShowAccountsWindow. Create connection to DB and show DB records.
        /// </summary>
        public ShowAccountsWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.Accounts.Load();
            accountsGrid.ItemsSource = db.Accounts.Local.ToBindingList();
            this.Closing += ShowAccounts_Closing;
        }
        /// <summary>
        /// Break DB connection, close ShowAccountsWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAccounts_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
