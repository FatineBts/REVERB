﻿/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using Newtonsoft.Json;
using class_blockchain;
using class_block;
using class_transaction;
using class_person;
using System.Text;
using class_smartgrid; 
using System.Diagnostics;
using class_task; 

namespace MainProgram
{
	class program
	{
		static void Blockchain()
		{
			// Creating a new chain
			Blockchain blockchain = new Blockchain();

			// // Creating transactions
			// //Test 1 :

			Person Aurel = new Person("Aurélien");
			Person Fatine = new Person("Fatine");
			Person Yassine = new Person("Yassine");
			Person Geng = new Person("Geng");
			Person Alexia = new Person("Alexia");

			Transaction transaction = new Transaction(Aurel, Fatine, 20); 

			blockchain.CreateTransaction(transaction); 

			// // miner process
			blockchain.ProcessPendingTransactions(Yassine);

			// // Creating transactions
			// //Test 2 :

			blockchain.CreateTransaction(new Transaction(Fatine, Geng, 5));
            blockchain.CreateTransaction(new Transaction(Fatine, Alexia, 5));
             blockchain.ProcessPendingTransactions(Yassine);


            Console.WriteLine($"Aurélien' balance: {blockchain.GetBalance(Aurel)}");
            Console.WriteLine($"Fatine' balance: {blockchain.GetBalance(Fatine)}");
            Console.WriteLine($"Alexia' balance: {blockchain.GetBalance(Alexia)}");
   	        Console.WriteLine($"Geng' balance: {blockchain.GetBalance(Geng)}");
            Console.WriteLine($"Yassine' balance: {blockchain.GetBalance(Yassine)}");

          	Console.WriteLine("=========================");
   			Console.WriteLine("=========================");
   			Console.WriteLine($"blockchain");
  			Console.WriteLine(JsonConvert.SerializeObject(blockchain, Formatting.Indented)); //convert into Jason format 
			Console.ReadKey();
			Person test = new Person();
			Person des = new Person();

			Transaction flu = new Transaction(test,des,100);
			if (flu.verify_signature())
			{
				Console.WriteLine("Bonne signature");
			}
			else Console.WriteLine("Mauvaise");

   		}
   		
   		static void SmartGrid()
   		{	

   			Console.WriteLine("=========================");
   			Console.WriteLine("=========================");
   			Console.WriteLine($"SmartGrid");

			// global variable of time
			String current_time = "08:02";
			SmartGrid s = new SmartGrid();
			Person lambda = new Person(); //in this class we load the data once for all 
			
			/*
			while(true)
			{
				current_time = DateTime.Now.ToString("HH:mm:ss"); //pour savoir si de nouvelles taches ont été crées, on parcourt la liste
				s.update(current_time);

				// we suppose that 1 s is equivalent to 1 min in the process
				System.Threading.Thread.Sleep(1000);
			}
			*/
			Task task = new Task();
			task.points_attribution();
			Console.WriteLine("task.points :"); 
			Console.WriteLine(task.points);
			
			lambda.action(current_time); 
			

		}

		static void Main()
		{		

			//Blockchain(); //easier to launch some simulations
			SmartGrid();
		}
	}
}