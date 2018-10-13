/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassin ABAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Text;
using System.Security.Cryptography;  

using data_class;
namespace class_block
{
	class Block 
	{ //will herite from all the public or protected methods
	
	/* Components of a block */

		public string _Data { get; private set; }//data entered in the block

		public int _Nonce { get; private set; }

		public string _PreviousHash { get; private set; }

		public string _Hash { get; private set; }

		public DateTime _TimeStamp { get; private set; }

		public Block(){} //default constructor

		public Block(string data, string previousHash, DateTime timestamp)
		{
			_Data= data; //we fill the function created previously with the entrees
			_PreviousHash=previousHash;
			_TimeStamp = timestamp;

			mineBlock();
		}

    	public string CalculateHash()  
    	{  
    		SHA256 sha256 = SHA256.Create();
    		byte[] inputBytes = Encoding.ASCII.GetBytes($"{_PreviousHash}-{_Data}-{_Nonce}");  
        	byte[] outputBytes = sha256.ComputeHash(inputBytes);  
        	return Convert.ToBase64String(outputBytes); 
    	}

    	public void mineBlock()
    	{
    		_Nonce = 0;

    		int difficulty = 3; // Number of symbol that we want
    		string proof = new String('g',difficulty);
    		do
    		{
    			_Hash = CalculateHash();
    			_Nonce++;
    			Console.WriteLine(_Nonce);

    		} while(_Hash.Substring(0,difficulty) != proof);
    	}
    	public void DisplayBlock()
    	{
    		string data = String.Format("Data: {0}, _Nonce : {1}, PreviousHash : {2}, _Hash : {3}", _Data,_Nonce,_PreviousHash,_Hash);
    		Console.WriteLine(data);

    	} 


	} // end of the class 


} //end of the namespace




