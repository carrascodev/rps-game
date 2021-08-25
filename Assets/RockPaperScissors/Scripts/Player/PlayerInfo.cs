using UnityEngine;

namespace RockPaperScissors
{
	[CreateAssetMenu(menuName = "RPS/Create PlayerInfo", fileName = "PlayerInfo", order = 0)]
	public class PlayerInfo : ScriptableObject
	{
		public bool isAi;
		public string playerName;
		public int startCoins;
		public Color playerColor;
	}
}