/*
##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Supervised by : François PÊCHEUX 

Realised by : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Text;
using System.IO;
using System.Collections.Generic; // to use list 
using System.Collections;
using System.Linq; // to use Last
using class_block;
using class_blockchain;
using class_transaction;
using class_person;
using class_task;
using class_house;

namespace class_smartgrid
{
	public class SmartGrid
	{

		public Blockchain _blockchain { get;  private set;}

        public List<House> _list_maison {get; private set;}

        public int _total_energy = 0;

        public List<Task> _total_task { get; private set;}


        public SmartGrid(int season)
        {   
            _blockchain = new Blockchain(); 
            _list_maison = new List<House>();
            InitSmartGrid(season);
        }

        

        public void InitSmartGrid(int season)
        {

            var Person_file = new StreamReader(File.OpenRead("Data/Person_file.txt"));
            while (!Person_file.EndOfStream)
            {
                var house = new House(season,Person_file.ReadLine());
                var member = new Person(1,Person_file.ReadLine()); // Father
                house.AddFamilyMember(member);    
                _list_maison.Add(house);

            } 
            //Console.WriteLine(_list_maison[0].name);
        }

        public void update(DateTime current_time)
        {
            List<Task> tache;
            foreach (var house in _list_maison)
            {
                foreach(var member in house._family)
                {
                    tache = member.action(current_time);

                    _total_task.AddRange(tache);
                }
            }
            Console.WriteLine("##### Before sort ##### \n");

            for(int i = 0;i<_total_task.Count;i++)
            {   
                Console.WriteLine("--"+i+"--\n"+_total_task[i].ToString());
            }
        }

         public void sort_task(DateTime current_time)
        {
            _total_task.RemoveAll(item => DateTime.Compare(item.end_time,current_time) < 0);
            _total_task = _total_task.OrderByDescending(x => x.points).ThenBy(x => x.consumption).ToList(); //so sort the elements 

            for(int i = 0; i < _total_task.Count; i++)
            {
                var house = _list_maison.First(x => x._familyName == _total_task[i].creator); // on peut sélectionner à chaque fois la même famille (faire un bool dans la création de la tâche pour dire si on peut exécuter ou non?)
                if(house._solar_panel_battery < _total_task[i].consumption)
                {
                    if(_total_energy > _total_task[i].consumption)
                    {
                        // Envoyer une requête aux autres
                    }
                    else
                    {
                        _total_task[i].recompute_time(30.0); // si pas assez d'énergie totale, on décale de 30 mins
                    }
                }
            }
        }


        public void update_energy(int task_energy)
        {
            //if we do a task then e need to substract this amount
            _total_energy-=task_energy;
            //no need to do that for a person since we have GetBalance  
            Console.WriteLine("Total_energy : "+_total_energy);
        }

	}

}
