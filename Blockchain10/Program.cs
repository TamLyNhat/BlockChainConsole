using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBitcoin;

namespace Blockchain10
{
    class Program
    {
        static void Main(string[] args)
        {
            //string genesisTransaction = "alexander chuyển 10đ cho pato";
            //Block genesisBlock = new Block("0", genesisTransaction);

            //Console.WriteLine("GenesisBlock: " + genesisBlock.GetType().);

            //Console.ReadKey();


            var myCoinBlockchain = new Blockchain();
            myCoinBlockchain.Difficulty = 1;

            // Received a block from the P2P network.
            // Validate 300 coins transfer.
            Console.WriteLine("Mining a block...");
            myCoinBlockchain.AddBlock(new Block(1, "03/12/2017", "300"));

            // this line below will cause the chain to be invalid.
            //myCoinBlockchain.GetLatestBlock().PreviousHash = "";

            // Validate the chain
            myCoinBlockchain.ValidateChain();


            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
