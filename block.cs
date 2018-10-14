/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassin ABAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Text;
using System.Security.Cryptography;  

using inter_block;
namespace class_block
{
	class Block : IBlock
	{ //will herite from all the public or protected methods
	
	/* Components of a block */

		public string Data { get; set; }//data entered in the block

		public int Nonce { get; set; }

		public string PreviousHash { get; set; }

		public string Hash { get; set; }

		public DateTime TimeStamp { get; set; }

		public Block(){} //default constructor

		public Block(string data, string previousHash, DateTime timestamp)
		{
			Data= data; //we fill the function created previously with the entrees
			PreviousHash=previousHash;
			TimeStamp = timestamp;

			mineBlock();
		}

    	public string CalculateHash()  
    	{  
    		SHA256 sha256 = SHA256.Create();
    		byte[] inputBytes = Encoding.ASCII.GetBytes($"{PreviousHash}-{Data}-{Nonce}");  
        	byte[] outputBytes = sha256.ComputeHash(inputBytes);  
        	return Convert.ToBase64String(outputBytes); 
    	}

    	public void mineBlock()
    	{
    		Nonce = 0;

    		int difficulty = 3; // Number of symbol that we want
    		string proof = new String('g',difficulty); //to have 3 times g at the beginning 
    		do
    		{
    			Hash = CalculateHash();
    			Nonce++;
    			//Console.WriteLine(_Nonce);

    		} while(Hash.Substring(0,difficulty) != proof); //while the condition below is not achieved
    	}
    	public void DisplayBlock()
    	{
    		string data = String.Format("Data: {0}, _Nonce : {1}, PreviousHash : {2}, _Hash : {3}", Data,Nonce,PreviousHash,Hash);
    		Console.WriteLine(data);

    	} 


	} // end of the class 


} //end of the namespace




