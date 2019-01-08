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

            for(int i = 0;i<_task.Count;i++)
            {   
                Console.WriteLine("--"+i+"--\n"+_task[i].ToString());
            }
        }

         public void sort_task(DateTime current_time)
        {
            _total_task.RemoveAll(item => DateTime.Compare(item.end_time,current_time) < 0);
            _total_task = _total_task.OrderByDescending(x => x.points).ThenBy(x => x.consumption).ToList(); //so sort the elements 

            for(int i = 0; i < _task.Count; i++)
            {
                var person = _list_maison.First(x => x._familyName == _total_task[i].creator); // on peut sélectionner à chaque fois la même famille (faire un bool dans la création de la tâche pour dire si on peut exécuter ou non?)
                if(person.Person_energy < _task[i].consumption)
                {
                    if(Total_energy > _total_task[i].consumption)
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

/*
	Etape 1 : on reprend la base de données en TXT et on retranscrit le fichier Python qui l'analysais en C#. Le fichier Python écrit en C# donnera une fonction "comportement" dans la classe SmartGrid. Cette fonction va servir à lire la base de données et créer des listes de personnes avec des besoins, des horaires, leur nom etc.-> GENG 
	But : obtenir un comportement humain. Pour le début, on simule des personnes qui ont de la production infinie et d'autres non (va permettre de mettre en place les transactions).
		
	Etape 2 : Reprendre la classe SmartGrid. Attribuer des productions infinies à certaines personnes pour avoir des transferts d'énergie. 
	Créer également une fonction qui va regarder le niveau d'énergie disponible (true false) et une seconde qui va mettre à jour le montant d'énergie disponible par maison (ie la variable AvailableEnergy).
			
	Etape 3 : enlever la production infinie et ordonnancer les différentes actions à effectuer (exemple : système de points). Effectivement, si on veut allumer la lumière la nuit on peut pas dire non. Si deux personnes veulent allumer le chauffage en même temps, qui sera prioritaire ? On pourrait faire un système de points : d'abord les actions obligatoires puis les actions qui sont dans un plage temporelle proche (1h). Dans cette plage temporaire, celles qui consomment pas d'énergie en premier et puis premier arrivé premier servi. 

*/