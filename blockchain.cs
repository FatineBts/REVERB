/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassin ABAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Text;
using System.Collections.Generic; // to use list 
using System.Collections;
using System.Linq; // to use Last
using inter_block;
using class_block;

namespace class_blockchain
{
	class Blockchain
		{

			public List<Block> _chain { get; private set;}
			public string _lastBlockHash {get; private set;}

			public Blockchain()
			{
				_chain = new List<Block>(); //create a list of Blocks
				_lastBlockHash = new String("00000000000");
			}

			public void AddBlock(Block NewBlock)
	    	{
	        	_chain.Add(NewBlock);
	        	_lastBlockHash = NewBlock.Hash;
	    	}

			public Block GetLatestBlock()
	    	{
	        	return _chain.Last(); //to get the last Block
	    	}


	   		public void DisplayBlockchain(int i)
	    	{
				string data = String.Format("Data: {0}, Nonce : {1}, PreviousHash : {2}, Hash : {3}", _chain[i].Data,_chain[i].Nonce,_chain[i].PreviousHash,_chain[i].Hash);
	    		Console.WriteLine(data);
	    	}

	    	public override string ToString()
	    	{
	    		StringBuilder res = new StringBuilder();
	    		for(int i = 0; i < _chain.Count; i++)
	    		{
	    			res.Append("\n--- Block " + i + " ---\n");
	    			res.Append(_chain[i].ToString());
	    		}

	    		return res.ToString();
	    	}
		}

}