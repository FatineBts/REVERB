using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using class_task;
using CsvHelper; 
using System.Collections.Generic; // to use list 
namespace class_house
{
	public class House
	{
		public List<Person> _family { get; private set;}
		float _solar_panel_battery;
		private RSACryptoServiceProvider key_pair;
		public RSAParameters public_key {get; private set;}

		public House(float production)
		{
			_solar_panel_battery = production;
			_family = new List<Person>();
			// Create a key pair
			key_pair = new RSACryptoServiceProvider();
			// Save public key information
			public_key = key_pair.ExportParameters(false);
			//Console.WriteLine(survey);
		}

		public AddFamilyMember()
		{
			Person 
			_family.Add(CreateFirstBlock());
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
		
		
		
	}

}