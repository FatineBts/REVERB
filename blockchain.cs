/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassin ABAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Collections.Generic; // to use list 
using System.Collections;
using System.Linq; // to use Last
using inter_block;
using class_block;

namespace class_blockchain
{
	class Blockchain : IEnumerable<IBlock>
		{

			List<IBlock> _chain; 

			public Blockchain()
			{
				_chain = new List<IBlock>(); //create a list of Blocks
					_chain.Add(CreateGenesisBlock()); //to add a first Block (genesis)
			}

			public void AddBlock(IBlock NewBlock)
	    	{
				NewBlock.PreviousHash = GetLatestBlock().Hash; 
	        	_chain.Add(NewBlock);
	        	//NewBlock.Hash = NewBlock.mineblock(); 
	    	}

			public IBlock CreateGenesisBlock() //is going to create the first block
			{
				return(new Block("Comment ca va ?","000000000",DateTime.Now)); 
			}

			public IBlock GetLatestBlock()
	    	{
	        	return _chain.Last(); //to get the last Block
	    	}


	   		public void DisplayBlockchain(int i)
	    	{
				string data = String.Format("Data: {0}, Nonce : {1}, PreviousHash : {2}, Hash : {3}", _chain[i].Data,_chain[i].Nonce,_chain[i].PreviousHash,_chain[i].Hash);
	    		Console.WriteLine(data);
	    	} 

        	public IEnumerator<IBlock> GetEnumerator()
        	{
            	return _chain.GetEnumerator();
        	}

        	IEnumerator IEnumerable.GetEnumerator()
        	{
            	return _chain.GetEnumerator();
       	 	}

		}

}