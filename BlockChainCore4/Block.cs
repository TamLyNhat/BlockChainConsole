using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainCore4
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        //public string Data { get; set; }

        public int Nonce { get; set; } = 0;

        public IList<Transaction> Transactions { get; set; }

        public Block(DateTime timeStamp, string previousHash, IList<Transaction> transactions)
        {
            Index = 0;
            TimeStamp = timeStamp;
            PreviousHash = previousHash;
            Transactions = transactions;
            //for (int i = 0; i < transactions.Count; i++)
            //    Transactions[i] = transactions[i];

            //Data = data;
            Hash = CalculateHash();
        }

        // Create the hash of the current block.
        //The CalculateHash method is also updated to use Transactions instead of Data to get hash of a block.
        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{JsonConvert.SerializeObject(Transactions)}-{Nonce}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }

        // This is how the mining works!
        public void Mine(int difficulty)
        {
            // You mined successfully if you found a hash with certain number of leading '0's
            // difficulty defines the number of '0's required 
            // e.g. if difficulty is 2, if you found a hash like  00338500000x..., it means you mined it.

            var leadingZeros = new string('0', difficulty);
            //var leadingZeros = "wwe";
            while (this.Hash == null || this.Hash.Substring(0, difficulty) != leadingZeros)
            {
                this.Nonce++;
                this.Hash = this.CalculateHash();
                Console.WriteLine("Mining:" + this.Hash);
            }

            Console.WriteLine("\nBlock has been mined: " + this.Hash + "\n");
            //Console.WriteLine();
        }
    }
}
