using Newtonsoft.Json;
using System;
using System.Xml;

namespace BlockChainCore
{
    class Program
    {
        // basic blockchain https://www.c-sharpcorner.com/article/blockchain-basics-building-a-blockchain-in-net-core/
        static void Main(string[] args)
        {
            BlockChain phillyCoin = new BlockChain();
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Henry,receiver:MaHesh,amount:10}"));
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:MaHesh,receiver:Henry,amount:5}"));
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Mahesh,receiver:Henry,amount:5}"));

            Console.WriteLine(JsonConvert.SerializeObject(phillyCoin, Newtonsoft.Json.Formatting.Indented));


            Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");
            Console.WriteLine();

            //thay đổi 1 giao dịch của 1 khối
            Console.WriteLine($"Update amount to 1000");
            phillyCoin.Chain[1].Data = "{sender:Henry,receiver:MaHesh,amount:1000}";

            Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");

            //Console.WriteLine();

            //phillyCoin.Chain[1].Hash = phillyCoin.Chain[1].CalculateHash();
            ////thay đổi tất cả giao dịch của 1 khối
            //Console.WriteLine($"Update the entire chain");
            //phillyCoin.Chain[2].PreviousHash = phillyCoin.Chain[1].Hash;
            //phillyCoin.Chain[2].Hash = phillyCoin.Chain[2].CalculateHash();
            //phillyCoin.Chain[3].PreviousHash = phillyCoin.Chain[2].Hash;
            //phillyCoin.Chain[3].Hash = phillyCoin.Chain[3].CalculateHash();

            //Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");

            Console.ReadLine();
        }
    }
}
