using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain10
{
    //public class Block
    //{
    //    private string previousHash;
    //    private string transactions;
    //    private string currentHash;

    //    public Block(string previousHash, string transactions)
    //    {
    //        this.previousHash = previousHash;
    //        this.transactions = transactions;

    //        byte[] data_transaction = SHA256Managed.Create().ComputeHash(Encoding.UTF8.GetBytes(transactions));
    //        string complied_contents = data_transaction.ToString() + previousHash;

    //        byte[] data_complied = SHA256Managed.Create().ComputeHash(Encoding.UTF8.GetBytes(complied_contents));
    //        this.currentHash = data_complied.ToString();
    //    }

    //}

    public class Block
    {
        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public string Timestamp { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }

        int _salt;

        public Block(int index, string timestamp, string data, string previousHash = "")
        {
            this.Index = index;
            this.PreviousHash = previousHash;
            this.Timestamp = timestamp;
            this.Data = data;
            this.Hash = this.CalculateHash();
            this._salt = 0;
        }


        // Create the hash of the current block.
        public string CalculateHash()
        {
            var hash = SHA256_hash(this.Index + this.PreviousHash + this.Timestamp + this.Data + this._salt);

            return hash;
        }

        // This is how the mining works!
        public void Mine(int difficulty)
        {
            // You mined successfully if you found a hash with certain number of leading '0's
            // difficulty defines the number of '0's required 
            // e.g. if difficulty is 2, if you found a hash like  00338500000x..., it means you mined it.
            while (this.Hash.Substring(0, difficulty) != new String('0', difficulty))
            {
                this._salt++;
                this.Hash = this.CalculateHash();
                Console.WriteLine("Mining:" + this.Hash);
            }

            Console.WriteLine("Block has been mined: " + this.Hash);
        }

        // Create a hash string from stirng
        static string SHA256_hash(string value)
        {
            var sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                var enc = Encoding.UTF8;
                var result = hash.ComputeHash(enc.GetBytes(value));

                foreach (var b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
