using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB
{
    /// <summary>
    /// Model of Account ot DB
    /// </summary>
    public class Account
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Money { get; set; }
    }
}
