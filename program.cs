using System;
using class_blockchain;
using class_block;
using inter_block;

namespace MainProgram
{
	class program
	{
		static void Main()
		{		
			// Test Block 
			IBlock block = new Block("La base","000000000",DateTime.Now);
			Console.WriteLine("Hash : {0}\nNonce : {1}",block.Hash,block.Nonce);
			//block.Data = "coucou";
			Console.WriteLine("{0}",block.Data);
			// block.DisplayBlock(); 
			// // Test Blockchain
			Blockchain blockchain = new Blockchain(); 
			blockchain.DisplayBlockchain(0); 
			blockchain.AddBlock(block); 
			blockchain.DisplayBlockchain(1); 
		}
	}
}
