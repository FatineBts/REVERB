using System;
using System.Text;

namespace class_task
{
	public class Task
	{

		public enum Level {Washing_machine, TV, Kitchen, Computer, Tool_bathroom, Cook, Light};

		// title of the task (number that will corresponds to the task)
		Level title = (Level)(0);//(Level)(new Random()).Next(0, 7); - j'ai mis à Washing_machine pour faire un test
		// consumption of the task for the duration
		float consumption;
		// duration of the task
		DateTime duration;
		//points given to a task
		public int points; 

/*
		public void test()
		{

			Console.WriteLine(Level.Washing_machine); // gives 0
			Console.WriteLine(title); // gives 0

		}

*/
		public void points_attribution()
		{
			switch (title)
      		{
          		case Level.Washing_machine:
              		points = 1; 
              		break;
          		case Level.TV:
              		points = 2;
              		break;
          		case Level.Kitchen:
              		points = 3;
              		break;
          		case Level.Computer:
              		points = 4;
              		break;              		              	
          		case Level.Tool_bathroom:
              		points = 5;
              		break;       
          		case Level.Cook:
              		points = 6;
              		break;  
          		case Level.Light:
              		points = 7;
              		break;               		            		
          		default:
              		points = 0;
              		break;
      		}	
		}
	}
}