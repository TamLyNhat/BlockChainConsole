using Newtonsoft.Json;
using System;

namespace BlockChainCore3
{
    class Program
    {
        //TRANSACTION AND REWARD
        //https://www.c-sharpcorner.com/article/building-a-blockchain-in-net-core-transaction-and-reward/

        static void Main(string[] args)
        {
            var startTime = DateTime.Now;

            BlockChain phillyCoin = new BlockChain();
            phillyCoin.CreateTransaction(new Transaction("Henry", "MaHesh", 10));

            /*From the screenshot, you can see there are two blocks.
            The first block is the genesis block and the second block is a normal block that contains a transaction from Henry to Mahesh.
            But, where is the reward transaction?
            The reward transaction is not there because the reward was added after a new block is processed.
            It will show up in the next block.*/

            phillyCoin.ProcessPendingTransactions("Bill");
            Console.WriteLine(JsonConvert.SerializeObject(phillyCoin, Formatting.Indented));

            phillyCoin.CreateTransaction(new Transaction("MaHesh", "Henry", 5));
            phillyCoin.CreateTransaction(new Transaction("Alexander", "abc", 10));
            phillyCoin.ProcessPendingTransactions("Bill");

            var endTime = DateTime.Now;

            Console.WriteLine($"Duration: {endTime - startTime}");

            //Console.WriteLine("=========================");
            //Console.WriteLine($"Henry' balance: {phillyCoin.GetBalance("Henry")}");
            //Console.WriteLine($"MaHesh' balance: {phillyCoin.GetBalance("MaHesh")}");
            //Console.WriteLine($"Bill' balance: {phillyCoin.GetBalance("Bill")}");

            Console.WriteLine("=========================");
            Console.WriteLine($"phillyCoin");
            Console.WriteLine(JsonConvert.SerializeObject(phillyCoin, Formatting.Indented));
            Console.ReadLine();
        }
    }
}
