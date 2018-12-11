using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using class_task;
using CsvHelper; 
using class_person; 
using class_block; 
using class_blockchain; 
using System.Collections.Generic; // to use list 

namespace class_house
{
	public class House
	{
		public List<Person> _family { get; private set;}
		float _solar_panel_battery;
		private RSACryptoServiceProvider key_pair;
		public RSAParameters public_key {get; private set;}
		public enum Season = {winter, autumn, spring, summer}; // summer <=> 4 kw, spring <=> 3 kw, autumn <=> 2 kw ,winter <=> 1 kw 
		private Season _season;

		public House(Season season)
		{
			_season = season; 
			_family = new List<Person>();
			// Create a key pair
			key_pair = new RSACryptoServiceProvider();
			// Save public key information
			public_key = key_pair.ExportParameters(false);
			//Console.WriteLine(survey);
		}
		public ChangeSeason(Season season)
		{
		 	_season = season;
		}

		public void AddProductionPerDay()
		{
			switch(_season)
			{
				case _season.winter:
					_solar_panel_battery = 1000;
					break;
				case _season.autumn:
					_solar_panel_battery = 2000;
					break;
				case _season.spring:
					_solar_panel_battery = 3000;
					break;
				case _season.summer:
					_solar_panel_battery = 4000;
					break;			
			}

		}

		public void AddFamilyMember(Person NewPerson)
		{
			_family.Add(NewPerson);
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

		public override string ToString()
		{
			return name+Encoding.UTF8.GetString(public_key.Modulus);
		}
		
		
		
	}

}