using System;
using System.Text.RegularExpressions;

namespace BankDB
{
    /// <summary>
    /// Start connection to DB
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
            }
        }
    }
}
