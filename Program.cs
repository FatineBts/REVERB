/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using class_blockchain;
using class_block;
using inter_block;
using class_transaction;
using Newtonsoft.Json;

namespace MainProgram
{
	class program
	{
		static void Main()
		{		
			// Creating a new chain
			Blockchain blockchain = new Blockchain();

			// Creating transactions
			//Test 1 :

			blockchain.CreateTransaction(new Transaction("Aurélien", "Fatine", 20)); 

			// miner process
			blockchain.ProcessPendingTransactions("Yassine");

			// Creating transactions
			//Test 2 :

			blockchain.CreateTransaction(new Transaction("Fatine", "Geng", 5));
            blockchain.CreateTransaction(new Transaction("Fatine", "Alexia", 5));
            blockchain.ProcessPendingTransactions("Yassine");


            Console.WriteLine($"Aurélien' balance: {blockchain.GetBalance("Aurélien")}");
            Console.WriteLine($"Fatine' balance: {blockchain.GetBalance("Fatine")}");
            Console.WriteLine($"Alexia' balance: {blockchain.GetBalance("Alexia")}");
            Console.WriteLine($"Geng' balance: {blockchain.GetBalance("Geng")}");
            Console.WriteLine($"Yassine' balance: {blockchain.GetBalance("Yassine")}");

            Console.WriteLine("=========================");

            Console.WriteLine("=========================");
            Console.WriteLine($"blockchain");
            Console.WriteLine(JsonConvert.SerializeObject(blockchain, Formatting.Indented));
			Console.ReadKey();


			// Test Block 
			//Block block0 = new Block("Block 0",blockchain._lastBlockHash,DateTime.Now);
			
			// // // Test Blockchain
			//blockchain.AddBlock(block0);
			//Console.WriteLine(blockchain);
			
			//Block block1 = new Block("Block 1",blockchain._lastBlockHash,DateTime.Now);
			//blockchain.AddBlock(block1);
			//Console.WriteLine(blockchain);
		}
	}
}