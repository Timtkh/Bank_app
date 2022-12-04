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
    /// Add money operation window
    /// </summary>
    public partial class AddMoneyWindow : Window
    {
        ApplicationContext db;

        /// <summary>
        /// Construct of AddMoneyWindow. Create connection to DB.
        /// </summary>
        public AddMoneyWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }
        /// <summary>
        /// Click to Add button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="FormatException"></exception>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.Parent as FrameworkElement;
            var nameTextBox = parent.FindName("nametextbox") as TextBox;
            var fundtextbox = parent.FindName("fundtextbox") as TextBox;
            var nameErrorTextBlock = parent.FindName("nameerrortextblock") as TextBlock;
            var fundErrorTextBlock = parent.FindName("funderrortextblock") as TextBlock;

            try
            {
                Account addedMoneyAccount = db.Accounts
                    .Where(a => a.Name == nameTextBox.Text)
                    .FirstOrDefault();

                if (addedMoneyAccount != null)
                {
                    int addedMoney = Int32.Parse(fundtextbox.Text);
                    addedMoneyAccount.Money += addedMoney;
                    db.SaveChanges();
                    MessageBox.Show("Added");
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
                nameErrorTextBlock.Visibility = Visibility.Visible;
            }
            catch (FormatException)
            {
                fundErrorTextBlock.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Hide error nameerrortextblock if name textbox was changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            nameerrortextblock.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Hide error funderrortextblock if fund textbox was changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fundTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            funderrortextblock.Visibility = Visibility.Hidden;
        }
    }

}
