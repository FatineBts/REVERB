using System;
using System.Collections.Generic; // to use list 
using System.Linq; // to use Last
using class_block;
namespace class_blockchain
{
	class Blockchain
		{

			List<Block> _chain; 

			public Blockchain()
			{
				_chain = new List<Block>(); //create a list of Blocks
				_chain.Add(CreateGenesisBlock()); //to add a first Block (genesis)
			}

			public Block CreateGenesisBlock() //is going to create the first block
			{
				return(new Block("Alexia doit 30 euros à Fatine","000000000",DateTime.Now)); 
			}

			public Block GetLatestBlock()
	    	{
	        	return _chain.Last(); //to get the last Block
	    	}

			public void AddBlock(Block NewBlock)
	    	{
	        	// NewBlock.PreviousHash = GetLatestBlock().Hash; 
	        	_chain.Add(NewBlock);
	    	}

	   		public void DisplayBlockchain(int i)
	    	{
				string data = String.Format("Data: {0}, Nonce : {1}, PreviousHash : {2}, Hash : {3}", _chain[i]._Data,_chain[i]._Nonce,_chain[i]._PreviousHash,_chain[i]._Hash);
	    		Console.WriteLine(data);
	    	} 
		}

}