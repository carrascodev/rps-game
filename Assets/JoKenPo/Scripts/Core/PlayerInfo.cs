using UnityEngine;

namespace JoKenPo
{
	[CreateAssetMenu(menuName = "JoKenPo/Create PlayerInfo", fileName = "PlayerInfo", order = 0)]
	public class PlayerInfo : ScriptableObject
	{
		public string playerName;
		public int startCoins;
	}
}