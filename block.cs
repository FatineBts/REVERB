/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassin ABAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System; 
using System.Security.Cryptography;  

namespace class_block
{
	class Block 
	{ //will herite from all the public or protected methods
	
	/* Components of a block */

		public string Data { get; set; }//data entered in the block

		public int Nonce { get; set; }

		public string PreviousHash { get; set; }

		public string Hash { get; set; }

		public DateTime TimeStamp { get; set; }

		public Block(){} //default constructor

		public Block(string data, int nonce, string previousHash, DateTime timeStamp)
		{		
			this.Data=data; //we fill the function created previously with the entrees
			this.Nonce=nonce; 
			this.PreviousHash=previousHash; 
			this.Hash=CalculateHash();
			this.TimeStamp=timeStamp;   
		}

    	public string CalculateHash()  
    	{  
    		SHA256 sha256 = SHA256.Create();
    		byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{Data}");  
        	byte[] outputBytes = sha256.ComputeHash(inputBytes);  
        	return Convert.ToBase64String(outputBytes); 
    	}

    	public void DisplayBlock()
    	{
    		string data = String.Format("Data: {0}, Nonce : {1}, PreviousHash : {2}, Hash : {3}, TimeStamp : {4}", this.Data,this.Nonce,this.PreviousHash,this.Hash, this.TimeStamp);
    		Console.WriteLine(data);

    	} 


	} // end of the class 


} //end of the namespace




