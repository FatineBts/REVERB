using System;
using System.Text;

namespace class_task
{
	public class Task
	{

		public enum Level {Washing_machine, TV, Oven_kitchen, Tool_Kitchen, Tool_bathroom, Heating, Light};

		// title of the task (number that will corresponds to the task)
		public Level _title;//(Level)(new Random()).Next(0, 7); - j'ai mis à Washing_machine pour faire un test
    public Level set_title(int number){ _title = (Level)(number); return _title;}
    // consumption of the task for the duration
		float consumption;
		// duration of the task
		DateTime begin_time;
    DateTime end_time;
		//points given to a task
		public int points; 

    public Task(int lvl, DateTime begin_time_task, int duration)
    {
      _title = (Level)(lvl);
      //Console.WriteLine(_title);
      begin_time = begin_time_task;
      end_time = begin_time.AddMinutes(duration);
      consumption = calculate_consumption(duration);
    }


    public float calculate_consumption(int duration)
    {
      float consumption = 1;
      return consumption;
    }

		public void points_attribution()
		{
			switch (_title)
      		{
          		case Level.Washing_machine:
              		points = 1; 
              		break;
          		case Level.TV:
              		points = 2;
              		break;
          		case Level.Oven_kitchen:
              		points = 3;
              		break;
          		case Level.Tool_Kitchen:
              		points = 4;
              		break;              		              	
          		case Level.Tool_bathroom:
              		points = 5;
              		break;       
          		case Level.Heating:
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