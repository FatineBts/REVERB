using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using class_task;
using CsvHelper; 

namespace class_person
{
	public class Person
	{
		// survey of human habit done by Tomaro team
		private static string[] survey = File.ReadAllLines("Data/SondageHabitudes.csv");
		public string name {get; private set;}
		public int random_line {get; private set;}
		private RSACryptoServiceProvider key_pair;
		public RSAParameters public_key {get; private set;}

		public Person()
		{
			name = "Default";
			// Create a key pair
			key_pair = new RSACryptoServiceProvider();
			// Save public key information
			public_key = key_pair.ExportParameters(false);

			random_line = new Random().Next(1, 284);
			//Console.WriteLine(survey);
		}

		public Person(string nom)
		{
			name = nom;
			// Create a key pair
			key_pair = new RSACryptoServiceProvider();
			// Save public key information
			public_key = key_pair.ExportParameters(false);

			random_line = new Random().Next(1, 284);
		}

		public string sign(Person dest, int amount)
		{
			byte[] originalData = Encoding.ASCII.GetBytes(this.ToString() + dest.ToString() + amount.ToString());
			byte[] signedData = key_pair.SignData(originalData, new SHA256CryptoServiceProvider());
			return Convert.ToBase64String(signedData);
		}

		public bool verify(Person dest, int amount, string sign_hash)
		{
			byte[] data_to_be_verify = Encoding.ASCII.GetBytes(this.ToString() + dest.ToString() + amount.ToString());

			return key_pair.VerifyData(data_to_be_verify, new SHA256CryptoServiceProvider(), Convert.FromBase64String(sign_hash));
		}
		
		
		// Retourne une liste de tâche qui sera inclus dans la liste principal du smartgrid
		public Task action(String current_time) 
		{
			//faudrait asigner une tache à une personne
			// int nbiter = 0;
			// string[] column;  
			// int iterateur;
			// int number_tasks = 20;

			int hour = Int32.Parse(current_time.Substring(11,2));
			if(hour == 0) //new day so we change the random_line
			{
				random_line = random_line = new Random().Next(1, 284);
			}

			double event_prob;
			Console.WriteLine(event_prob);
			/* For each time interval we check if we have to turn on a device.
			*/
			if(hour >= 0 && hour < 6)
			{	
				event_prob = new Random().NextDouble();
				if(event_prob > tv_prob_0_6)
				{
					// turn on TV with the time stored in survey[random_line]
				}

				event_prob = new Random().NextDouble();
				if(event_prob > pc_prob_0_6)
				{
					// turn on PC
				}
			}
			else if (hour >= 6 && hour < 9)
			{

			}
			else if (hour >= 9 && hour < 12)
			{
				
			}
			else if (hour >= 12 && hour < 15)
			{
				
			}
			else if (hour >= 15 && hour < 18)
			{
				
			}
			else if (hour >= 18 && hour < 21)
			{
				
			}
			else if (hour >= 6 && hour < 0)
			{
				
			}
			else if (hour >= 21)
			{

			}

			return new Task();

			// for( int i = 1; i < number_tasks; i ++){
			// foreach (String l in survey) //we check the data base 
			// {
   //  			if (nbiter == 0)
   //  			{
 		// 			Console.WriteLine("Line:");
   //      			Console.WriteLine(survey[random_line]); 
			// 		column = survey[random_line].Split(',');

			// 		int random_line_print = random_line + 1; 
   //      			Console.WriteLine("line selected : " + random_line_print);

   //      			Console.WriteLine("l1");
   //      			for(iterateur = 0; iterateur < 7 ; iterateur++) //columns B - H - Jour travaillé - Jeux vidéos + TV
   //      			{
 		// 				Console.WriteLine(column[iterateur]); 
 		// 				task.set_title(1); //TV
   //      			}

   //      			Console.WriteLine("l2");
   //      			for(iterateur = 7; iterateur < 14; iterateur++) //I - O -  Jour travaillé - Ordinateur/Tablette
   //      			{
 		// 				Console.WriteLine(column[iterateur]);
 		// 				task.set_title(3);  //Computer
   //      			}

   //      			Console.WriteLine("l3");
   //      			for(iterateur = 14; iterateur < 21; iterateur++)  //P - V -  Jour travaillé - Four 
   //      			{	
   //      				Console.WriteLine(column[iterateur]); 
   //      				task.set_title(2); //Kitchen
   //      			}

			// 		Console.WriteLine("l4");
   //      			for(iterateur = 21; iterateur < 28; iterateur++) //W - AC -  Jour travaillé - Appareil cuisine courte durée (machine café...)
   //      			{
   //      				Console.WriteLine(column[iterateur]);
   //      				task.set_title(5); //Cook
   //      			}

   //      			Console.WriteLine("l5");
   //      			for(iterateur = 28; iterateur < 35; iterateur++) //AD - AJ -  Jour travaillé - Appareil salle de bain courte durée (lisseur...)
   //      			{
   //      				Console.WriteLine(column[iterateur]);
   //      				task.set_title(4); //Tool_bathroom
   //      			}

   //      			Console.WriteLine("l6");
   //      			for(iterateur = 35; iterateur < 42; iterateur++) //AK - AQ - Jour non travaillé - Jeux vidéos + TV
   //      			{
   //      				Console.WriteLine(column[iterateur]);
   //      			}

			// 		Console.WriteLine("l7");
   //      			for(iterateur = 42; iterateur < 49; iterateur++) //AR - AX - Jour non travaillé - Ordinateur/Tablette
   //      			{
   //      				Console.WriteLine(column[iterateur]);
   //      			}

   //      			Console.WriteLine("l8");
   //      			for(iterateur = 49; iterateur < 56 ; iterateur++) //AY - BE - Jour non travaillé - Four
   //      			{
   //      				Console.WriteLine(column[iterateur]);
   //      			}

   //      			Console.WriteLine("l9");
   //      			for(iterateur = 56; iterateur < 63 ; iterateur++) //BF - BL - Jour non travaillé - Appareil cuisine courte durée (machine café...)
   //      			{
   //      				Console.WriteLine(column[iterateur]);
   //      			}

   //      			Console.WriteLine("l10");
   //      			for(iterateur = 63; iterateur < 70 ; iterateur++) //BM - BS - Jour non travaillé - Appareil salle de bain courte durée (lisseur...)
   //      			{
   //      				Console.WriteLine(column[iterateur]);
   //      			}

   //      			nbiter = 1;  //to have only one line 
   //  			}
			// }//end foreach 
 		// }//end for 
		}
	
		public override string ToString()
		{
			return name+Encoding.UTF8.GetString(public_key.Modulus);
		}
	}

}
