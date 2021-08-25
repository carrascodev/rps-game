using System;
using UnityEngine;

namespace RockPaperScissors
{

	[Serializable]
	public struct GameRule
	{
		public int NumberOfRounds;
		public int RoundsToWin;
	}
	
	[CreateAssetMenu(menuName = "RPS/Create GameSettings", fileName = "GameSettings", order = 0)]
	public class GameSettings : ScriptableObject, ISerializationCallbackReceiver
	{
		[Range(10, 30)]
		public int initialBet;

		[Range(30, 80)]
		public int maxBet = 50;
		
		public GameRule rule;
		[SerializeField]
		float defaultStateDelay = 0.4f;

		public WaitForSeconds DefaultStateDelay { get; private set; }
		public void OnBeforeSerialize()
		{
			
		}

		public void OnAfterDeserialize()
		{
			DefaultStateDelay = new WaitForSeconds(defaultStateDelay);
		}
	}
}