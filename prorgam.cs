using System;
// using class_blockchain;
using class_block;

namespace MainProgram
{
	class program
	{
		static void Main()
		{		
			// Test Block 
			Block block = new Block("Geng doit 20 euros à Fatine","000000000",DateTime.Now);
			Console.WriteLine("Hash: {0}\nNonce : {1}",block._Hash,block._Nonce);
			// block.Data = "coucou";
			// Console.WriteLine("{0},{1}",block.Data,block.Nonce);
			// block.DisplayBlock(); 
			// // Test Blockchain
			// Blockchain blockchain = new Blockchain(); 
			// blockchain.DisplayBlockchain(0); 
			// blockchain.AddBlock(new Block("Aurélien doit 40 euros à Fatine",blockchain._chain[0].Nonce+1,blockchain._chain[0].Hash,DateTime.Now)); 
			// blockchain.DisplayBlockchain(1);
		}
	}
}
