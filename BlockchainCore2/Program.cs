using System;

namespace BlockchainCore2
{
    class Program
    {
        //https://www.c-sharpcorner.com/article/building-a-blockchain-in-net-core-proof-of-work/
        //proof if work
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;

            BlockChain phillyCoin = new BlockChain();
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Henry,receiver:MaHesh,amount:10}"));
            //phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:MaHesh,receiver:Henry,amount:5}"));
            //phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Mahesh,receiver:Henry,amount:5}"));

            var endTime = DateTime.Now;

            Console.WriteLine($"Duration: {endTime - startTime}");

            Console.ReadLine();
        }
    }
}
