using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using class_task;
using CsvHelper; 
using System.Collections.Generic; // to use list 
namespace class_person
{
	public class Person
	{
		// survey of human habit done by Tomaro team
		private static string[] survey = File.ReadAllLines("Data/SondageHabitudes.csv");
		public string name {get; private set;}
		public string[] habit {get; private set;}
		private RSACryptoServiceProvider key_pair;
		public RSAParameters public_key {get; private set;}
        List<Task> list_tache = new List<Task>(); // List where all the task of the person are stored
		
		public Person()
		{
			name = "Default";
			// Create a key pair
			key_pair = new RSACryptoServiceProvider();
			// Save public key information
			public_key = key_pair.ExportParameters(false);

			int random_line = new Random().Next(1, 284);
			habit = survey[random_line].Split(",");
			//Console.WriteLine(survey);
		}

		public Person(string nom)
		{
			name = nom;
			// Create a key pair
			key_pair = new RSACryptoServiceProvider();
			// Save public key information
			public_key = key_pair.ExportParameters(false);

			int random_line = new Random().Next(1, 284);
			habit = survey[random_line].Split(",");
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

		
		//fonction to get the proba depending on the values in the file

		public double probability(int column)
		{
			int counter = 0; 
			string[] habit2; 
			double proba = 0.0; 
			Console.WriteLine("#####################################");
			Console.WriteLine("column : " + column);
		
			for(int line = 1; line <283; line++) //we read all the lines 
			{
				habit2 = survey[line].Split(",");
				//Console.WriteLine("habit2[column] : "+ habit2[column]+ ", column :" + column);
				
				if(Int32.Parse(habit2[column]) != 0)
				{
					//Console.WriteLine("habit2 ! = 0 : "+ habit2[column]+ ", column :" + column);
					counter+=1; 
				} 
			}

			//Console.WriteLine("counter : " + counter);
			proba = (double) counter/ (double) 283; 
			return proba; 
		}

		// Retourne une liste de tâche qui sera inclus dans la liste principal du smartgrid
		public List<Task> action(DateTime current_time) 
		{
			//faudrait asigner une tache à une personne
			double tv_prob_0_6 = 0.04593639576;
			double tv_prob_6_9 = 0.1413427562;
			double tv_prob_9_12 = 0.01766784452;
			double tv_prob_12_15 = 0.08480565371;
			double tv_prob_15_18 = 0.08833922261;
			double tv_prob_18_21 = 0.5335689046;
			double tv_prob_21_0 = 0.5441696113;

			double pc_prob_0_6 = 0.09187279152;
			double pc_prob_6_9 = 0.2897526502;
			double pc_prob_9_12 = 0.4310954064;
			double pc_prob_12_15 = 0.4664310954;
			double pc_prob_15_18 = 0.5477031802;
			double pc_prob_18_21 = 0.7703180212;
			double pc_prob_21_0 = 0.6643109541;

		//public enum Level {Washing_machine, TV, Oven_kitchen, Tool_Kitchen, Tool_bathroom, Heating, Light};

			double Ovenkitchen_prob_0_6 = 0.0;
			double Ovenkitchen_prob_6_9 = 0.0353356890459364;
			double Ovenkitchen_prob_9_12 = 0.03886925795053;
			double Ovenkitchen_prob_12_15 = 0.127208480565371;
			double Ovenkitchen_prob_15_18 = 0.0106007067137809;
			double Ovenkitchen_prob_18_21 = 0.787985865724382;
			double Ovenkitchen_prob_21_0 = 0.0989399293286219;

			double ToolKitchen_prob_0_6 = 0.0;
			double ToolKitchen_prob_6_9 = 0.664310954063604;
			double ToolKitchen_prob_9_12 = 0.148409893992933;
			double ToolKitchen_prob_12_15 = 0.261484098939929;
			double ToolKitchen_prob_15_18 = 0.102473498233216;
			double ToolKitchen_prob_18_21 = 0.65017667844523;
			double ToolKitchen_prob_21_0 = 0.212014134275618;

/*
			double Heating_prob_0_6 = 0.09187279152;
			double Heating_prob_6_9 = 0.2897526502;
			double Heating_prob_9_12 = 0.4310954064;
			double Heating_prob_12_15 = 0.4664310954;
			double Heating_prob_15_18 = 0.5477031802;
			double Heating_prob_18_21 = 0.7703180212;
			double Heating_prob_21_0 = 0.6643109541;

			double Light_prob_0_6 = 0.09187279152;
			double Light_prob_6_9 = 0.2897526502;
			double Light_prob_9_12 = 0.4310954064;
			double Light_prob_12_15 = 0.4664310954;
			double Light_prob_15_18 = 0.5477031802;
			double Light_prob_18_21 = 0.7703180212;
			double Light_prob_21_0 = 0.6643109541;
*/

			int hour = Int32.Parse(current_time.ToString().Substring(11,2));
			
			if(hour == 0) //new day so we change the random_line
			{
				int random_line = new Random().Next(1, 284);
				habit = survey[random_line].Split(",");
			}

			double event_prob;
			
			/* For each time interval we check if we have to turn on a device.
			*/
			if(hour >= 0 && hour < 6)
			{	
				event_prob = new Random().NextDouble();
				if(event_prob < tv_prob_0_6)
				{	
					if(Int32.Parse(habit[6]) != 0)
					{
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[6])));
						Console.WriteLine(name+" turns on tv for "+habit[6]);
					}
				}

				if(event_prob < pc_prob_0_6)
				{	
					if(Int32.Parse(habit[13]) != 0)
					{
						list_tache.Add(new Task(2,current_time,Int32.Parse(habit[13])));
						Console.WriteLine(name+" uses the pc for "+habit[13]);
					}
				}

				if(event_prob < Ovenkitchen_prob_0_6)
				{	
					if(Int32.Parse(habit[20]) != 0)
					{
						list_tache.Add(new Task(3,current_time,Int32.Parse(habit[20])));
						Console.WriteLine(name+" turns on the oven for "+habit[20]);
					}
				}

				if(event_prob < ToolKitchen_prob_0_6)
				{	
					if(Int32.Parse(habit[27]) != 0)
					{
						list_tache.Add(new Task(4,current_time,Int32.Parse(habit[27])));
						Console.WriteLine(name+" uses the kitchen for "+habit[27]);
					}
				}

			}
			else if (hour >= 6 && hour < 9)
			{
				event_prob = new Random().NextDouble();
				if(event_prob < tv_prob_6_9)
				{	
					if(Int32.Parse(habit[0]) != 0)
					{
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[0])));
						Console.WriteLine(name+" turns on tv for "+habit[0]);
					}
				}

				if(event_prob < pc_prob_6_9)
				{	
					if(Int32.Parse(habit[7]) != 0)
					{
						list_tache.Add(new Task(2,current_time,Int32.Parse(habit[7])));
						Console.WriteLine(name+" uses the pc for "+habit[7]);
					}
				}

				if(event_prob < Ovenkitchen_prob_6_9)
				{	
					if(Int32.Parse(habit[14]) != 0)
					{
						list_tache.Add(new Task(3,current_time,Int32.Parse(habit[14])));
						Console.WriteLine(name+" turns on the oven for "+habit[14]);
					}
				}				

				if(event_prob < ToolKitchen_prob_6_9)
				{	
					if(Int32.Parse(habit[21]) != 0)
					{
						list_tache.Add(new Task(4,current_time,Int32.Parse(habit[21])));
						Console.WriteLine(name+" uses the kitchen for "+habit[21]);
					}
				}
			}
			else if (hour >= 9 && hour < 12)
			{
				event_prob = new Random().NextDouble();
				if(event_prob < tv_prob_9_12)
				{	
					if(Int32.Parse(habit[1]) != 0)
					{
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[1])));
						Console.WriteLine(name+" turns on tv for "+habit[1]);
					}
				}

				if(event_prob < pc_prob_9_12)
				{	
					if(Int32.Parse(habit[8]) != 0)
					{
						list_tache.Add(new Task(2,current_time,Int32.Parse(habit[8])));
						Console.WriteLine(name+" uses the pc for "+habit[8]);
					}
				}

				if(event_prob < Ovenkitchen_prob_9_12)
				{	
					if(Int32.Parse(habit[15]) != 0)
					{
						list_tache.Add(new Task(3,current_time,Int32.Parse(habit[15])));
						Console.WriteLine(name+" turns on the oven for "+habit[15]);
					}
				}	

				if(event_prob < ToolKitchen_prob_9_12)
				{	
					if(Int32.Parse(habit[22]) != 0)
					{
						list_tache.Add(new Task(4,current_time,Int32.Parse(habit[22])));
						Console.WriteLine(name+" uses the kitchen for "+habit[22]);
					}
				}							
			}
			else if (hour >= 12 && hour < 15)
			{
				event_prob = new Random().NextDouble();
				if(event_prob < tv_prob_12_15)
				{	
					if(Int32.Parse(habit[2]) != 0)
					{
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[2])));
						Console.WriteLine(name+" turns on tv for "+habit[2]);
					}
				}

				if(event_prob < pc_prob_12_15)
				{	
					if(Int32.Parse(habit[9]) != 0)
					{
						list_tache.Add(new Task(2,current_time,Int32.Parse(habit[9])));
						Console.WriteLine(name+" uses the pc for "+habit[9]);
					}
				}

				if(event_prob < Ovenkitchen_prob_12_15)
				{	
					if(Int32.Parse(habit[16]) != 0)
					{
						list_tache.Add(new Task(3,current_time,Int32.Parse(habit[16])));
						Console.WriteLine(name+" turns on the oven for "+habit[16]);
					}
				}

				if(event_prob < ToolKitchen_prob_12_15)
				{	
					if(Int32.Parse(habit[23]) != 0)
					{
						list_tache.Add(new Task(4,current_time,Int32.Parse(habit[23])));
						Console.WriteLine(name+" uses the kitchen for "+habit[23]);
					}
				}	
			}
			else if (hour >= 15 && hour < 18)
			{
				event_prob = new Random().NextDouble();
				if(event_prob < tv_prob_15_18)
				{	
					if(Int32.Parse(habit[3]) != 0)
					{
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[3])));
						Console.WriteLine(name+" turns on tv for "+habit[3]);
					}
				}

				if(event_prob < pc_prob_15_18)
				{	
					if(Int32.Parse(habit[10]) != 0)
					{
						list_tache.Add(new Task(2,current_time,Int32.Parse(habit[10])));
						Console.WriteLine(name+" uses the pc for "+habit[10]);
					}
				}

				if(event_prob < Ovenkitchen_prob_15_18)
				{	
					if(Int32.Parse(habit[17]) != 0)
					{
						list_tache.Add(new Task(3,current_time,Int32.Parse(habit[17])));
						Console.WriteLine(name+" turns on the oven for "+habit[17]);
					}
				}

				if(event_prob < ToolKitchen_prob_15_18)
				{	
					if(Int32.Parse(habit[24]) != 0)
					{
						list_tache.Add(new Task(4,current_time,Int32.Parse(habit[24])));
						Console.WriteLine(name+" uses the kitchen for "+habit[24]);
					}
				}					
			}
			else if (hour >= 18 && hour < 21)
			{
				event_prob = new Random().NextDouble();
				if(event_prob < tv_prob_18_21)
				{	
					if(Int32.Parse(habit[4]) != 0)
					{
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[4])));
						Console.WriteLine(name+" turns on tv for "+habit[4]);
					}
				}

				if(event_prob < pc_prob_18_21)
				{	
					if(Int32.Parse(habit[11]) != 0)
					{
						list_tache.Add(new Task(2,current_time,Int32.Parse(habit[11])));
						Console.WriteLine(name+" uses the pc for "+habit[11]);
					}
				}

				if(event_prob < Ovenkitchen_prob_18_21)
				{	
					if(Int32.Parse(habit[18]) != 0)
					{
						list_tache.Add(new Task(3,current_time,Int32.Parse(habit[18])));
						Console.WriteLine(name+" turns on the oven for "+habit[18]);
					}
				}

				if(event_prob < ToolKitchen_prob_18_21)
				{	
					if(Int32.Parse(habit[25]) != 0)
					{
						list_tache.Add(new Task(4,current_time,Int32.Parse(habit[25])));
						Console.WriteLine(name+" uses the kitchen for "+habit[25]);
					}
				}	
			}
			else if (hour >= 21)
			{
				event_prob = new Random().NextDouble();
				if(event_prob < tv_prob_21_0)
				{	
					if(Int32.Parse(habit[5]) != 0)
					{
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[5])));
						Console.WriteLine(name+" turns on tv for "+habit[5]);
					}
				}

				if(event_prob < pc_prob_21_0)
				{	
					if(Int32.Parse(habit[12]) != 0)
					{
						list_tache.Add(new Task(2,current_time,Int32.Parse(habit[12])));
						Console.WriteLine(name+" uses the pc for "+habit[12]);
					}
				}

				if(event_prob < Ovenkitchen_prob_21_0)
				{	
					if(Int32.Parse(habit[19]) != 0)
					{
						list_tache.Add(new Task(3,current_time,Int32.Parse(habit[19])));
						Console.WriteLine(name+" turns on the oven for "+habit[19]);
					}
				}

				if(event_prob < ToolKitchen_prob_21_0)
				{	
					if(Int32.Parse(habit[26]) != 0)
					{
						list_tache.Add(new Task(4,current_time,Int32.Parse(habit[26])));
						Console.WriteLine(name+" uses the kitchen for "+habit[26]);
					}
				}	
			}

			return list_tache;
		}
	
		public void Chosen_Task(Person person, int lvl, DateTime current_time, int duration) //to add a new task into the list 
    	{
      		list_tache.Add(new Task(lvl,current_time,duration)); 
      		Console.WriteLine("Task, lvl : " + lvl + ", current_time : " + current_time + ", duration : " + duration); 
    	}

		public override string ToString()
		{
			return name+Encoding.UTF8.GetString(public_key.Modulus);
		}
	}

}
