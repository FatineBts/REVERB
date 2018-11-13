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

		enum Level {Washing_machine, TV, Kitchen, Computer, Tool_bathroom, Cook, Light};
		// enum Hour {early_morning, morning, noon, afternoon, evening, midnight}; 
		//Washing_machine : machine à laver, oven : four, light : lumière

		public List<Task> _task { get; private set;}
		// public Person Person { get;  private set;}  
		// //public Transaction Transaction{get; private set;}
		// public int Time { get; private set;} 
		// public string Name { get; private set;}
		// public int Amount { get; private set;}
		// public string Task{get; private set;}

	  //   public SmartGrid(Person person, int amount, int time, string task)
   //      {
   //      	Person = person; 
			// Time = time; 
			// Name = person.name; 
			// Amount = amount; 
			// Task = task;
   //          _task = new List<SmartGrid>();
			// InitializeTask(); 
   //      } 

        public SmartGrid()
        {
            _list_maison = new List<Person>();
            _task = new List<Task>();
            InitPerson();
        }

        // public SmartGrid CreateTask(Person person, int amount, int time, string task) //creates a chosen person
   	    // {
        // 	SmartGrid smartgrid = new SmartGrid(person, amount, time, task);
        //    	return smartgrid;
        // }

        // public SmartGrid RandomTask() //checks for one available person
        // {
        // 	SmartGrid smartgrid = behaviour();
        // 	return smartgrid; 

        // }

        // public SmartGrid behaviour() //comportement
        // {

        // 	Random aleatoire = new Random();
        // 	int random = aleatoire.Next(10); //0 -> 9

        // 	//ouvre la base de donnée et prend le nom correspondant au numéro random (ici Francois) (à faire)
        // 	Person person = new Person("Francois");

        // 	Random random2 = new Random();
        // 	int random_task = random2.Next(7); //0 -> 6
        // 	Level level; 
        // 	string task = "Washing_machine"; 

        // 	Random random3 = new Random();
        // 	int random_amount = random3.Next(10000);

        // 	Random random4 = new Random(); 
        // 	int random_time = random4.Next(6); 
        // 	int time = 3; 

        // 	SmartGrid choice = new SmartGrid(person, random_amount, time, task);
        // 	return choice; 
        // }

        public List<Person> _list_maison {get; private set;}

        public void InitPerson()
        {
            var Person_file = new StreamReader(File.OpenRead("Data/Person_file.txt"));
            while (!Person_file.EndOfStream) _list_maison.Add(new Person(Person_file.ReadLine()));
            // Console.WriteLine(_list_maison[0].name);
        }

        public void update(String current_time)
        {
            foreach (var personne in _list_maison)
            {
                // personne.action();
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