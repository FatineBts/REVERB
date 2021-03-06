/*
##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Supervised by : François PÊCHEUX 

Realised by : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

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
		public string _familyName; // firstname
		public float _solar_panel_battery {get;set;}
		private RSACryptoServiceProvider key_pair;
		public RSAParameters public_key { get; private set; }
		public enum Season {winter, autumn, spring, summer}; // summer <=> 4 kw, spring <=> 3 kw, autumn <=> 2 kw ,winter <=> 1 kw 
		private Season _season;

		public House(int season, string name)
		{
			_season = (Season)(season); 
			_family = new List<Person>();
			_familyName = name;
			_solar_panel_battery = 1000; // tout le monde commence avec 1000kw
			// Create a key pair
			key_pair = new RSACryptoServiceProvider();
			// Save public key information
			public_key = key_pair.ExportParameters(false);
			//Console.WriteLine(survey);
		}

		public void ChangeSeason(Season season)
		{
		 	_season = season;
		}

		public void AddProductionPerDay()
		{
			switch(_season)
			{
				case Season.winter:
					_solar_panel_battery = 100;
					break;
				case Season.autumn:
					_solar_panel_battery = 200;
					break;
				case Season.spring:
					_solar_panel_battery = 300;
					break;
				case Season.summer:
					_solar_panel_battery = 400;
					break;			
			}

		}

		public void AddFamilyMember(Person NewPerson)
		{
			NewPerson.house_name = this._familyName;
			_family.Add(NewPerson);
		}

		public string sign(House dest, float amount)
		{
			byte[] originalData = Encoding.ASCII.GetBytes(this.ToString() + dest.ToString() + amount.ToString());
			byte[] signedData = key_pair.SignData(originalData, new SHA256CryptoServiceProvider());
			return Convert.ToBase64String(signedData);
		}

		public bool verify(House dest, float amount, string sign_hash)
		{
			byte[] data_to_be_verify = Encoding.ASCII.GetBytes(this.ToString() + dest.ToString() + amount.ToString());

			return key_pair.VerifyData(data_to_be_verify, new SHA256CryptoServiceProvider(), Convert.FromBase64String(sign_hash));
		}

		public override string ToString()
		{
			return _familyName;
		}
		
		
		
	}

}