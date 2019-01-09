/*
##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Supervised by : François PÊCHEUX 

Realised by : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic; // to use list 
using System.Collections;
using System.Linq; 
using class_transaction;
// using Newtonsoft.Json;


namespace class_block
{
	public class Block
	{ //will herite from all the public or protected methods
        public int Index { get; set; }

		public IList<Transaction> Transactions { get; set; } // a list of transactions

		public int Nonce { get; private set;} = 0;

		public string PreviousHash { get; set;}

		public string Hash { get; set;}

		public DateTime TimeStamp { get; private set;}

		public Block(){} //default constructor

		public Block(DateTime timeStamp, string previousHash, IList<Transaction> transactions)
		{
			Index = 0;
            TimeStamp = timeStamp;
            PreviousHash = previousHash;
            Transactions = transactions;

		}

    	public string CalculateHash()  
    	{  
    		SHA256 sha256 = SHA256.Create();
    		byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{Transactions}-{Nonce}"); 
        	byte[] outputBytes = sha256.ComputeHash(inputBytes);  
        	return Convert.ToBase64String(outputBytes); 
    	}

    	public void mineBlock(int difficulty)
    	{

    		string proof = new String('g',difficulty); //to have 3 times g at the beginning 
    		do
    		{
    			Hash = CalculateHash();
    			Nonce++;
    			//Console.WriteLine(_Nonce);

    		} while(Hash.Substring(0,difficulty) != proof); //while the condition below is not achieved
    	}

    	public override string ToString()
    	{
            StringBuilder res = new StringBuilder();
            res.Append("PreviousHash: "+PreviousHash+"\nHash: "+ Hash+"\nTime: "+ TimeStamp.ToString("G"));
            for(int i = 0; i < Transactions.Count; i++)
            {
                res.Append("\n--- Transaction " + i + " ---\n");
                res.Append(Transactions[i].ToString());
            }

            return res.ToString();
    	}
	} // end of the class 


} //end of the namespace