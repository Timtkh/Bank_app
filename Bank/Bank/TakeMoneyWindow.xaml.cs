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
    /// Take money operation window
    /// </summary>
    public partial class TakeMoneyWindow : Window
    {
        ApplicationContext db;

        /// <summary>
        /// Construct of TakeMoneyWindow. Create connection to DB.
        /// </summary>
        public TakeMoneyWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        /// <summary>
        /// Withdraw money from account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.Parent as FrameworkElement;
            var nameTextBox = parent.FindName("nametextbox") as TextBox;
            var fundTextBox = parent.FindName("fundtextbox") as TextBox;
            var nameErrorTextBlock = parent.FindName("nameerrortextblock") as TextBlock;
            var fundErrorTextBlock = parent.FindName("funderrortextblock") as TextBlock;

            try
            {
                Account withdrawnMoneyAccount = db.Accounts
                    .Where(a => a.Name == nameTextBox.Text)
                    .FirstOrDefault();

                if (withdrawnMoneyAccount != null)
                {
                    int withdrawnMoney = Int32.Parse(fundtextbox.Text);
                    if (withdrawnMoneyAccount.Money - withdrawnMoney >= 0)
                    {
                        withdrawnMoneyAccount.Money -= withdrawnMoney;
                        db.SaveChanges();
                        MessageBox.Show("Withdrawn");
                        db.Dispose();
                        Close();
                    }
                    else
                    {
                        throw new FormatException();
                    }
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
