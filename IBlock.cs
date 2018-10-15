/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassine ABBAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;
using System.Text;
using System.Collections.Generic; // to use list 
using System.Collections;
using class_transaction;

namespace inter_block
{
	public interface IBlock
	{

		/* Components of a block */

		int Index { get; set; }

		IList<Transaction> Transactions { get; set; } // a list of transaction

		int Nonce { get;}

		string PreviousHash { get;}

		string Hash { get;}

		DateTime TimeStamp { get;}
	}
}