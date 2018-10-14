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

		string Data { get; set;}

		int Nonce { get; set; }

		string PreviousHash { get; set; }

		string Hash { get; set; }

		DateTime TimeStamp { get; set;}
	}
}