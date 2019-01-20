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

using Newtonsoft.Json;

namespace class_smartgrid
{
	public class SmartGrid
	{

		public Blockchain _blockchain { get;  private set;}

        public List<House> _list_maison {get; private set;}

        public float _total_energy = 0;

        public List<Task> _total_task { get; private set;}


        public SmartGrid(int season)
        {   
            _blockchain = new Blockchain(); 
            _list_maison = new List<House>();
            _total_task = new List<Task>();
            InitSmartGrid(season);

            foreach(var house in _list_maison)
            {
                _total_energy += house._solar_panel_battery;
            }

            Console.WriteLine("Création d'un SmartGrid avec " + _total_energy + "kw");
        }


        public void InitSmartGrid(int season)
        {

            var Person_file = new StreamReader(File.OpenRead("Data/Person_file.txt"));
            while (!Person_file.EndOfStream)
            {
                var name = Person_file.ReadLine();
                var house = new House(season,name);
                var member = new Person(1,name); // Father
                house.AddFamilyMember(member);    
                _list_maison.Add(house);

            } 
            //Console.WriteLine(_list_maison[0].name);
        }

        public void update(DateTime current_time)
        {
            List<Task> tache;
            for (int i = 0; i < _list_maison.Count; i++)
            {
                _list_maison[i].AddProductionPerDay(); // à chaque heure on actualise la production
                foreach(var member in _list_maison[i]._family)
                {
                    tache = member.action(current_time);

                    _total_task.AddRange(tache);
                }
            }

            if(current_time.ToString("HH") == "00") // si c'est minuit
            {
                _blockchain.ProcessPendingTransactions(_list_maison[0]);

                Console.WriteLine(JsonConvert.SerializeObject(_blockchain, Formatting.Indented)); //convert into Jason format 

                System.Threading.Thread.Sleep(10000);
            }

            Console.WriteLine("##### Before sort ##### \n");

            for(int i = 0;i<_total_task.Count;i++)
            {   
                Console.WriteLine("--"+i+"--\n"+_total_task[i].ToString());
            }

            sort_task(current_time);

            Console.WriteLine("##### After sort ##### \n");

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

                int indice_house = _list_maison.FindIndex(x => x._familyName == _total_task[i].creator);
                // var house = _list_maison.First(x => x._familyName == _total_task[i].creator); // on peut sélectionner à chaque fois la même famille (faire un bool dans la création de la tâche pour dire si on peut exécuter ou non?)
                
                if(_list_maison[indice_house]._solar_panel_battery < _total_task[i].consumption) // Si la maison n'a pas assez d'énergie
                {
                    if(_total_energy > _total_task[i].consumption)
                    {
                        for(int j = 0; j < _list_maison.Count; j++) // on regarde si y a un potentielle donneur
                        {
                            if (_list_maison[j]._solar_panel_battery > _total_task[i].consumption) // si une maison a une énergie plus élevé que celle demandé
                            {
                                var donneur = _list_maison[j];
                                var receveur = _list_maison[indice_house];

                                Console.WriteLine("Création de Transaction");
                                Console.WriteLine("\n Donneur: " + _list_maison[j]._familyName);
                                Console.WriteLine("\n Receveur: " + _list_maison[indice_house]._familyName);
                                Console.WriteLine("Energie de la tâche: " + _total_task[i].consumption);
                                Console.WriteLine("Energie échangé: " + (_total_task[i].consumption - _list_maison[indice_house]._solar_panel_battery) + "\n");

                                _blockchain.CreateTransaction(new Transaction(ref donneur, ref receveur, _total_task[i].consumption - _list_maison[indice_house]._solar_panel_battery));

                                _list_maison[j] = donneur;
                                _list_maison[indice_house] = receveur;
                        
                                // Console.WriteLine("\n\n Après Transaction \n\n Donneur: " + _list_maison[j]._solar_panel_battery);
                                // Console.WriteLine("\n Receveur: " + _list_maison[indice_house]._solar_panel_battery);
                                System.Threading.Thread.Sleep(10000);
                                break;
                            }
                        }
                    }
                    else
                    {
                        _total_task[i].recompute_time(30.0); // si pas assez d'énergie totale, on décale de 30 mins
                    }
                }
                else // si la maison a assez d'énergie
                {
                    _list_maison[indice_house]._solar_panel_battery -= _total_task[i].consumption;
                }

            }
        }


        public void update_energy(float task_energy)
        {
            //if we do a task then e need to substract this amount
            _total_energy-=task_energy;
            //no need to do that for a person since we have GetBalance  
            Console.WriteLine("Total_energy : "+_total_energy);
        }

	}

}
