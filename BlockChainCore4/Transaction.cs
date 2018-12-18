using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainCore4
{
    //A new Class, Transaction, is created to contain information that was contained in JSON format.
    public class Transaction
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public int Amount { get; set; }

        public Transaction(string fromAddress, string toAddress, int amount)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Amount = amount;
        }
    }
}
