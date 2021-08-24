using UnityEngine;

namespace JoKenPo
{
	[CreateAssetMenu(menuName = "JoKenPo/Create GameSettings", fileName = "GameSettings", order = 0)]
	public class GameSettings : ScriptableObject
	{
		[Range(0, 30)]
		public int initialBet;
	}
}