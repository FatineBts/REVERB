/*

##### REVERB Project ######## Polytech Sorbonne - 2018/2019 #########

Encadrant : François PÊCHEUX 

Participants : Yassin ABAR - Aurélien ABEL - Fatine BENTIRES ALJ - Geng REN - Alexia ZOUNIAS-SIRABELLA

*/

using System;

namespace inter_block
{
	public interface IBlock
	{

		/* Components of a block */

		string Data { get;}//data entered in the block

		int Nonce { get;}

		string PreviousHash { get;}

		string Hash { get;}

		DateTime TimeStamp { get;}
	}
}