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
			// Creating a new chain
			Blockchain blockchain = new Blockchain(); 

			// Test Block 
			Block block0 = new Block("Block 0",blockchain._lastBlockHash,DateTime.Now);
			
			// // // Test Blockchain
			blockchain.AddBlock(block0);
			//Console.WriteLine(blockchain);
			
			Block block1 = new Block("Block 1",blockchain._lastBlockHash,DateTime.Now);
			blockchain.AddBlock(block1);
			Console.WriteLine(blockchain);
		}
	}
}
