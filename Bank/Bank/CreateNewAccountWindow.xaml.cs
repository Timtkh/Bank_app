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
    /// Create new account operation window
    /// </summary>
    public partial class CreateNewAccountWindow : Window
    {
        ApplicationContext db;

        /// <summary>
        /// Construct of CreateNewAccountWindow. Create connection to DB.
        /// </summary>
        public CreateNewAccountWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        /// <summary>
        /// Create new account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="FormatException"></exception>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.Parent as FrameworkElement;
            var textBox = parent.FindName("accountnametextbox") as TextBox;
            var textBlock1 = parent.FindName("accountnameerrortextblock") as TextBlock;
            var listAZ = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c);
            var listAz = listAZ.Select(char.ToLower);
            var LatinAlphabet = listAZ.Concat(listAz).ToArray();

            try
            {
                bool check = false;
                var textBoxCharArray = textBox.Text;
                for (int i = 0; i < textBoxCharArray.Length; i++)
                {
                    for (int j = 0; j < LatinAlphabet.Length; j++)
                    {
                        if (textBoxCharArray[i] == LatinAlphabet[j])
                        {
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        throw new FormatException();
                    }
                    check = false;
                }

                Account newAccount = new Account { Name = textBox.Text, Money = 0 };
                db.Accounts.Add(newAccount);
                db.SaveChanges();
                MessageBox.Show("Submited");
                db.Dispose();
                Close();
            }
            catch (FormatException)
            {
                textBlock1.Visibility = Visibility.Visible;
            }

        }

        /// <summary>
        /// Hide error accountnameerrortextblock if account name textbox was changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accountNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            accountnameerrortextblock.Visibility = Visibility.Hidden;
        }
    }

}
