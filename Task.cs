/*
##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########
Supervised by : François PÊCHEUX 
Realised by : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA
*/

using System;
using System.Text;

namespace class_task
{

  public enum Level {Washing_machine, TV, Oven_kitchen, Tool_Kitchen, Tool_bathroom, Heating, Light};

  public class Task
  {

    // title of the task (number that will corresponds to the task)
    public Level _title;//(Level)(new Random()).Next(0, 7); - j'ai mis à Washing_machine pour faire un test
    public Level set_title(int number){ _title = (Level)(number); return _title;}

    public string creator {get; private set;}
    // consumption of the task for the duration
    public float consumption {get; private set;}
    // duration of the task
    public DateTime begin_time {get; private set;}
    public float duration {get; private set;}
    public DateTime end_time {get; private set;}
    //points given to a task
    public int points; 

    public Task(int lvl, DateTime begin_time_task, float duration, string name)
    {
      _title = (Level)(lvl);
      // Console.WriteLine(_title);
      begin_time = begin_time_task;
      duration = duration;
      end_time = begin_time.AddMinutes(duration);
      consumption = calculate_consumption(duration);
      creator = name;
      points_attribution();
    }

    public void recompute_time(double time)
    {

      begin_time = begin_time.AddMinutes(time);
      end_time = begin_time.AddMinutes(duration);
    }

    public float calculate_consumption(float duration)
    {

      switch (_title)
          {
              case Level.Washing_machine:
                  return 470/60 * duration;
                  
              case Level.TV:
                  return 100/60 * duration;
                  
              case Level.Oven_kitchen:
                  return 1200/60 * duration;
                  
              case Level.Tool_Kitchen:
                  return 300/60 * duration;
                                                    
              case Level.Tool_bathroom:
                  return 800/60 * duration;
                         
              case Level.Heating:
                  return 1000/60 * duration; // arbitraire
                    
              case Level.Light:
                  return 40/60 * duration;
                                                    
              default:
                  return duration;
                  
          }
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


    public override string ToString()
    {
      return "Creator: "+creator+"\nPriority: "+points+"\nConsumption: " +consumption + "\nStarting time: " + begin_time;
    }


  }
}