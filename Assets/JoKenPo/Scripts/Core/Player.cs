using System;
using System.Collections;
using UnityEngine;

namespace JoKenPo
{
	[Serializable]
	public class Player
	{
		[SerializeField]
		PlayerInfo info;
		
		public string Name { get; private set; }
		public int Coins { get; private set; }
		
		public HandChoice CurrentHand { get; private set; }

		public void Initialize()
		{
			Name = info.playerName;
			AddCoins(info.startCoins);
		}

		public void AddCoins(int amount)
		{
			Coins += amount;
		}

		public void SetHand(HandChoice choice)
		{
			CurrentHand = choice;
		}
	}
}