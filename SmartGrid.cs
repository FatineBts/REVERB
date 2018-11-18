using System;
using System.Text;
using System.IO;
using System.Collections.Generic; // to use list 
using System.Collections;
using System.Linq; // to use Last
using class_block;
using class_transaction;
using class_person;
using class_task;

namespace class_smartgrid
{
	public class SmartGrid
	{

		// enum Hour {early_morning, morning, noon, afternoon, evening, midnight}; 

		public List<Task> _task { get; private set;}
        public List<Person> _list_maison {get; private set;}

        public SmartGrid()
        {
            _list_maison = new List<Person>(); //corresponds to the list of persons living in the houses
            _task = new List<Task>();
            InitPerson();
        }

        

        public void InitPerson()
        {
            var Person_file = new StreamReader(File.OpenRead("Data/Person_file.txt"));
            while (!Person_file.EndOfStream) _list_maison.Add(new Person(Person_file.ReadLine()));
            //Console.WriteLine(_list_maison[0].name);
        }

        public void update(String current_time)
        {
            Task tache;
            foreach (var personne in _list_maison)
            {
                tache = personne.action(current_time);

            }
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