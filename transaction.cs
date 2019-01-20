/*
##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Supervised by : François PÊCHEUX 

Realised by : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Text;
using System.Collections.Generic; // to use list 
using System.Collections;
using System.Linq; // to use Last
using class_person;
using class_house;

namespace class_transaction
{
	public class Transaction  
	{  
    	public House FromAddress { get;  private set; }  
    	public House ToAddress { get;  private set; }  
    	public float Amount { get; private set; }
        public string sign_hash {get; private set;}

  
    	public Transaction(ref House src, ref House dest, float amount)  
    	{  
            FromAddress = src;
            ToAddress = dest;  
        	Amount = amount;
            sign_hash = sign_transaction();
            src._solar_panel_battery -= amount;
            dest._solar_panel_battery += amount;
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