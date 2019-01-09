/*
##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Supervised by : François PÊCHEUX 

Realised by : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Text;
using System.Collections.Generic; // to use list 
using System.Collections;
using System.Linq; // to use Last
using class_block;
using class_transaction;
using class_person;
using class_house;
using class_smartgrid;


namespace class_blockchain
{
	public class Blockchain
		{

			public List<Block> _chain { get; private set;}
			public string _lastBlockHash {get; private set;}
			IList<Transaction> PendingTransactions = new List<Transaction>(); // a list of pending transactions 
			public int Difficulty { set; get; } = 2;
        	public int Reward = 1; //1 cryptoreward

			public Blockchain()
        	{
            	InitializeChain();
            	AddFirstBlock();
        	}

        	 public void InitializeChain()
        	{
            	_chain = new List<Block>();
        	}

        	public Block CreateFirstBlock()
   	    	{
        		Block block = new Block(DateTime.Now, null, PendingTransactions);
            	block.mineBlock(Difficulty);
            	PendingTransactions = new List<Transaction>();
            	return block;
        	}

        	public void AddFirstBlock()
        	{
            	_chain.Add(CreateFirstBlock());
        	}

        	public Block GetLatestBlock()
	    	{
	        	return _chain.Last(); //to get the last Block
	    	}

			public void AddBlock(Block NewBlock)

	    	{
	    		Block latestBlock = GetLatestBlock();  
        		NewBlock.Index = latestBlock.Index + 1;  
        		NewBlock.PreviousHash = latestBlock.Hash;  
        		NewBlock.Hash = NewBlock.CalculateHash();
        		NewBlock.mineBlock(Difficulty);
	        	_chain.Add(NewBlock);
	     
	    	}

	    	public void CreateTransaction(Transaction transaction)  
			{  
    			PendingTransactions.Add(transaction);  
			}

			public void ProcessPendingTransactions(House minerAddress)  
			{  
    			Block block = new Block(DateTime.Now, GetLatestBlock().Hash, PendingTransactions);  
    			AddBlock(block);  
  
    			PendingTransactions = new List<Transaction>();  
    			CreateTransaction(new Transaction(new House(0,"inconnu"), minerAddress, Reward));  
			}

			public bool IsValid()
        	{
            	for (int i = 1; i < _chain.Count; i++)
            	{
                	Block currentBlock = _chain[i];
                	Block previousBlock = _chain[i - 1];

            		if (currentBlock.Hash != currentBlock.CalculateHash()) // when we update transaction data 
                	{
                    	return false;
                	}

                	if (currentBlock.PreviousHash != previousBlock.Hash) //  link between blocks is invalid 
                	{
                    	return false;
                	}
            	}
            return true;
        	}

        	public int GetBalance(House address ,SmartGrid smartgrid) // get balance for one address 
        	{
            	int balance = 0;

            	for (int i = 0; i < _chain.Count; i++)
            	{
                	for (int j = 0; j < _chain[i].Transactions.Count; j++)
                	{
                    	var transaction = _chain[i].Transactions[j];

                    	if (transaction.FromAddress == address && balance>transaction.Amount)
                    	{
                        	balance -= transaction.Amount;
                            smartgrid.update_energy(transaction.Amount); //we only do that once
                    	}

                    	if (transaction.ToAddress == address && balance>transaction.Amount)
                    	{
                        	balance += transaction.Amount;
                    	}
                	}
            	}

            return balance;
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