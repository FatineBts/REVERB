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
		public enum _figures {Mother,Father,Child,Grandfather,Grandmother,Teenager};
		private static string[] survey = File.ReadAllLines("Data/SondageHabitudes.csv");
		public string name {get; private set;}
		public string[] habit {get; private set;}
		public List<Task> _task { get; private set;}
		private _figures _figure;


		public Person(int figure,string name)
		{
			_figure = (_figures)(figure);
			 name = name; 

			int random_line = new Random().Next(1, 284);
			habit = survey[random_line].Split(",");
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

			// double pc_prob_0_6 = 0.09187279152;
			// double pc_prob_6_9 = 0.2897526502;
			// double pc_prob_9_12 = 0.4310954064;
			// double pc_prob_12_15 = 0.4664310954;
			// double pc_prob_15_18 = 0.5477031802;
			// double pc_prob_18_21 = 0.7703180212;
			// double pc_prob_21_0 = 0.6643109541;

			int hour = Int32.Parse(current_time.ToString().Substring(11,2));

			// List where all the task of the person are stored
			List<Task> list_tache = new List<Task>();

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
						// turn on tv
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[6])));
						Console.WriteLine(name+" turn on tv for "+habit[6]);
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
						// turn on tv
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[0])));
						Console.WriteLine(name+" turn on tv for "+habit[0]);
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
						// turn on tv
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[1])));
						Console.WriteLine(name+" turn on tv for "+habit[1]);
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
						// turn on tv
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[2])));
						Console.WriteLine(name+" turn on tv for "+habit[2]);
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
						// turn on tv
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[3])));
						Console.WriteLine(name+" turn on tv for "+habit[3]);
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
						// turn on tv
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[4])));
						Console.WriteLine(name+" turn on tv for "+habit[4]);
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
						// turn on tv
						list_tache.Add(new Task(1,current_time,Int32.Parse(habit[5])));
						Console.WriteLine(name+" turn on tv for "+habit[5]);
					}
				}
			}

			return list_tache;

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
			return name;
		}
	}

}
