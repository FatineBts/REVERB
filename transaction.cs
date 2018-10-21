/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Text;
using System.Collections.Generic; // to use list 
using System.Collections;
using System.Linq; // to use Last
using class_person;

namespace class_transaction
{
	public class Transaction  
	{  
    	public Person FromAddress { get;  private set; }  
    	public Person ToAddress { get;  private set; }  
    	public int Amount { get; private set; }
        public string sign_hash {get; private set;}

  
    	public Transaction(Person src, Person dest, int amount)  
    	{  
            FromAddress = src;
            ToAddress = dest;  
        	Amount = amount;
            sign_hash = sign_transaction();
    	}  

        public string sign_transaction()
        {
            return FromAddress.sign(ToAddress,Amount);
        }

        public bool verify_signature()
        {
            return FromAddress.verify(ToAddress,Amount,sign_hash);
        }
	}  
} 