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
    /// Delete account operation window
    /// </summary>
    public partial class DeleteAccountWindow : Window
    {
        ApplicationContext db;

        /// <summary>
        /// Construct of DeleteAccountWindow. Create connection to DB.
        /// </summary>
        public DeleteAccountWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        /// <summary>
        /// Click to Delete button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NullReferenceException"></exception>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            var parent = button.Parent as FrameworkElement;
            var accountNameTextBox = parent.FindName("accountnametextbox") as TextBox;
            var accountNameErrorTextBlock = parent.FindName("accountnameerrortextblock") as TextBlock;
            try
            {
                Account deletedAccount = db.Accounts
                    .Where(a => a.Name == accountNameTextBox.Text)
                    .FirstOrDefault();
                if (deletedAccount != null)
                {
                    db.Accounts.Remove(deletedAccount);
                    db.SaveChanges();
                    MessageBox.Show("Deleted");
                    db.Dispose();
                    Close();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (NullReferenceException)
            {
                accountNameErrorTextBlock.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Hide error accountnameerrortextblock if account textbox was changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accountnametextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            accountnameerrortextblock.Visibility = Visibility.Hidden;
        }
    }

}
