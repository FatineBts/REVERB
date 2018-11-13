/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
// using Newtonsoft.Json;
using class_blockchain;
using class_block;
using class_transaction;
using class_person;
using System.Text;
using class_smartgrid; 
using System.Diagnostics;

namespace MainProgram
{
	class program
	{
		static void Run()
		{
			// Creating a new chain
			// Blockchain blockchain = new Blockchain();

			// // Creating transactions
			// //Test 1 :

			// Person Aurel = new Person("Aurélien");
			// Person Fatine = new Person("Fatine");
			// Person Yassine = new Person("Yassine");
			// Person Geng = new Person("Geng");
			// Person Alexia = new Person("Alexia");

			// Transaction transaction = new Transaction(Aurel, Fatine, 20); 

			// blockchain.CreateTransaction(transaction); 

			// // miner process
			// blockchain.ProcessPendingTransactions(Yassine);

			// // Creating transactions
			// //Test 2 :

			// blockchain.CreateTransaction(new Transaction(Fatine, Geng, 5));
   //          blockchain.CreateTransaction(new Transaction(Fatine, Alexia, 5));
   //          blockchain.ProcessPendingTransactions(Yassine);


   //          Console.WriteLine($"Aurélien' balance: {blockchain.GetBalance(Aurel)}");
   //          Console.WriteLine($"Fatine' balance: {blockchain.GetBalance(Fatine)}");
   //          Console.WriteLine($"Alexia' balance: {blockchain.GetBalance(Alexia)}");
   //          Console.WriteLine($"Geng' balance: {blockchain.GetBalance(Geng)}");
   //          Console.WriteLine($"Yassine' balance: {blockchain.GetBalance(Yassine)}");

   //          Console.WriteLine("=========================");
   //          Console.WriteLine("=========================");
   //          Console.WriteLine($"blockchain");
   //          // Console.WriteLine(JsonConvert.SerializeObject(blockchain, Formatting.Indented)); //convert into Jason format 
			// Console.ReadKey();
			// Person test = new Person();
			// Person des = new Person();

			// Transaction flu = new Transaction(test,des,100);
			// if (flu.verify_signature())
			// {
			// 	Console.WriteLine("Bonne signature");
			// }
			// else Console.WriteLine("Mauvaise");

   //          Console.WriteLine("=========================");
   //          Console.WriteLine("=========================");
   //          Console.WriteLine($"SmartGrid");

			// SmartGrid smartgrid = new SmartGrid(Fatine,10,1, "TV"); 
			// Console.WriteLine("Name of the user : " + smartgrid.Person.name);
			// Console.WriteLine(smartgrid.Amount);
			// Console.WriteLine(smartgrid.CreateTask(Geng, 20, 1, "Computer").Amount); //returns 20
			// Console.WriteLine(smartgrid.RandomTask().Name); //returns 20


			// global variable of time
			String current_time;
			SmartGrid s = new SmartGrid();
			Person lambda = new Person();
			while(true)
			{
				current_time = DateTime.Now.ToString("HH:mm:ss");
				s.update(current_time);


				// On suppose que une seconde est équivalente à 1 minute dans la modélisation
				System.Threading.Thread.Sleep(1000);
			}

		}

		static void Main()
		{		

			Run(); //easier to launch some simulations

		}
	}
}