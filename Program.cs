/*
##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Supervised by : François PÊCHEUX 

Realised by : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

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
using class_house;

namespace MainProgram
{
	class program
	{
		static void Blockchain()
		{
			// Creating a new chain
			Blockchain blockchain = new Blockchain();
			SmartGrid s = new SmartGrid(1); //winter

			// // Creating transactions
			// //Test 1 :

			Person Aurel = new Person(1,"Aurélien");
			Person Fatine = new Person(0,"Fatine");
			Person Yassine = new Person(1,"Yassine");
			Person Geng = new Person(1,"Geng");
			Person Alexia = new Person(0,"Alexia");

			House AurelFamily = new House(0,"Abel");
			AurelFamily.AddFamilyMember(Aurel);	
			House FatineFamily = new House(0,"Bentires");
			FatineFamily.AddFamilyMember(Fatine);
			House YassineFamily = new House(0,"Abbar");
			YassineFamily.AddFamilyMember(Yassine);
			House GengFamily = new House(0,"Ren");
			GengFamily.AddFamilyMember(Geng);

			House AlexiaFamily = new House(0,"ZOUNIAS-SIRABELLA");
			AlexiaFamily.AddFamilyMember(Alexia);

			Transaction transaction = new Transaction(ref AurelFamily, ref FatineFamily, 20); 

			blockchain.CreateTransaction(transaction); 

			// // miner process
			blockchain.ProcessPendingTransactions(YassineFamily);

			// // Creating transactions
			// //Test 2 :

			blockchain.CreateTransaction(new Transaction(ref FatineFamily, ref GengFamily, 5));
            blockchain.CreateTransaction(new Transaction(ref FatineFamily, ref AlexiaFamily, 5));
             blockchain.ProcessPendingTransactions(YassineFamily);


            Console.WriteLine($"Aurélien' balance: {blockchain.GetBalance(AurelFamily,s)}");
            Console.WriteLine($"Fatine' balance: {blockchain.GetBalance(FatineFamily,s)}");
            Console.WriteLine($"Alexia' balance: {blockchain.GetBalance(AlexiaFamily,s)}");
   	        Console.WriteLine($"Geng' balance: {blockchain.GetBalance(GengFamily,s)}");
            Console.WriteLine($"Yassine' balance: {blockchain.GetBalance(YassineFamily,s)}");

          	Console.WriteLine("=========================");
   			Console.WriteLine("=========================");
   			Console.WriteLine($"blockchain");
  			Console.WriteLine(JsonConvert.SerializeObject(blockchain, Formatting.Indented)); //convert into Jason format 
			Console.ReadKey();
			House test = new House(0,"Y");
			House des = new House(0,"Z");

			Transaction flu = new Transaction(ref test,ref des,100);
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
			DateTime current_time = DateTime.Now;
			// DateTime current_time = new DateTime(2018, 11, 21, 19, 20,30); // (YYYY, MM, DD, HH,mm,ss)
			
			SmartGrid s = new SmartGrid(0); // winter 
			// // Person lambda = new Person(); //in this class we load the data once for all 
			
			// Person Joey = new Person(1,"Joey");
			// Joey.Chosen_Task(Joey, 2,current_time,15);  
			// double p = Joey.probability(26);
			// Console.WriteLine("probability : " + p); 
	
			while(true) //each min we check the list of tasks
			{
				Console.WriteLine("\n"+current_time.ToString()); 
				s.update(current_time);
				// we suppose that 1 s is equivalent to 1 min in the process
				current_time = current_time.AddMinutes(60.0); //each 60 min just for the test 
				System.Threading.Thread.Sleep(1000);
			}
					
		}


		static void Main()
		{		

			// Blockchain(); //easier to launch some simulations
			SmartGrid();
		}
	}
}