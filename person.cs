using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using class_task;
using CsvHelper; 

namespace class_person
{
	public class Person
	{
		// survey of human habit done by Tomaro team
		private static String survey = File.ReadAllText("Data/SondageHabitudes.csv");

		public string name {get; private set;}
		private RSACryptoServiceProvider key_pair;
		public RSAParameters public_key {get; private set;}
	
		public Person()
		{
			name = "Default";
			// Create a key pair
			key_pair = new RSACryptoServiceProvider();
			// Save public key information
			public_key = key_pair.ExportParameters(false);

			//Console.WriteLine(survey);
		}

		public Person(string nom)
		{
			name = nom;
			// Create a key pair
			key_pair = new RSACryptoServiceProvider();
			// Save public key information
			public_key = key_pair.ExportParameters(false);
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
		
		
		public void action(String current_time) //à remettre de type Task
		{
			//var a = 1; //nmbre aléatoire et on fonction du nombre on prend une ligne 
			//faudrait asigner une tache à une personne
			int i = 0;

			foreach (char line in survey)
			{
				int random = (new Random()).Next(0, 283); //number of line
				i++; 

    			if (i==random)
    			{
        			Console.WriteLine("Test action(String current_time : ok"); 	
    			}
			}

			i = 0; 
		}
	
		public override string ToString()
		{
			return name+Encoding.UTF8.GetString(public_key.Modulus);
		}
	}

}
