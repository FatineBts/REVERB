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

namespace class_transaction
{
	public class Transaction  
	{  
    	public string FromAddress { get; set; }  
    	public string ToAddress { get; set; }  
    	public int Amount { get; set; }  
  
    	public Transaction(string fromAddress, string toAddress, int amount)  
    	{  
        	FromAddress = fromAddress;  
        	ToAddress = toAddress;  
        	Amount = amount;  
    	}  
	}  
} 