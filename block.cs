/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassin ABAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Text;  
using System.Security.Cryptography; 
using System.Collections.Generic; // to use list  
using System.Linq; // to use Last


namespace blockchain
{

	class Block 
	{ //will herite from all the public or protected methods
	
	/* Components of a block */

		public string Data { get; set; }//data entered in the block

		public int Nonce { get; set; }

		public string PreviousHash { get; set; }

		public string Hash { get; set; }

		public DateTime TimeStamp { get; set; }

		public Block(){} //default constructor

		public Block(string data, int nonce, string previousHash, DateTime timeStamp)
		{		
			this.Data=data; //we fill the function created previously with the entrees
			this.Nonce=nonce; 
			this.PreviousHash=previousHash; 
			this.Hash=CalculateHash();
			this.TimeStamp=timeStamp;   
		}

    	public string CalculateHash()  
    	{  
    		SHA256 sha256 = SHA256.Create();
    		byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{Data}");  
        	byte[] outputBytes = sha256.ComputeHash(inputBytes);  
        	return Convert.ToBase64String(outputBytes); 
    	}

    	public void DisplayBlock()
    	{
    		string data = String.Format("Data: {0}, Nonce : {1}, PreviousHash : {2}, Hash : {3}, TimeStamp : {4}", this.Data,this.Nonce,this.PreviousHash,this.Hash, this.TimeStamp);
    		Console.WriteLine(data);

    	} 


	} // end of the class 


	class Blockchain : Block 
	{

		List<Block> _chain; 

		Blockchain()
		{
			this._chain = new List<Block>(); //create a list of Blocks
			this._chain.Add(CreateGenesisBlock()); //to add a first Block (genesis)
		}

		Block CreateGenesisBlock() //is going to create the first block
		{
			return(new Block("Alexia doit 30 euros à Fatine",0,"000000000",DateTime.Now)); 
		}

		Block GetLatestBlock()
    	{
        	return this._chain.Last(); //to get the last Block
    	}

		void AddBlock(Block NewBlock)
    	{
        	NewBlock.PreviousHash = this.GetLatestBlock().Hash; 
        	this._chain.Add(NewBlock);
    	}

   		void DisplayBlockchain(int i)
    	{
			string data = String.Format("Data: {0}, Nonce : {1}, PreviousHash : {2}, Hash : {3}, TimeStamp : {4}", this._chain[i].Data,this._chain[i].Nonce,this._chain[i].PreviousHash,this._chain[i].Hash, this._chain[i].TimeStamp);
    		Console.WriteLine(data);
    	} 

		static void Main()
		{
			
			// Test Block 
			Block block = new Block("Geng doit 20 euros à Fatine",0,"000000000",DateTime.Now);
			block.DisplayBlock(); 
			// Test Blockchain
			Blockchain blockchain = new Blockchain(); 
			blockchain.DisplayBlockchain(0); 
			blockchain.AddBlock(new Block("Aurélien doit 40 euros à Fatine",blockchain._chain[0].Nonce+1,blockchain._chain[0].Hash,DateTime.Now)); 
			blockchain.DisplayBlockchain(1);
		}

	}

} //end of the namespace




