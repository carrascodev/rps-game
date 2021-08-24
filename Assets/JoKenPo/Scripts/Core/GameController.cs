using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace JoKenPo
{
	public enum SimpleGameControllerState
	{
		Initializing,
		WaitingInteraction,
		Finished,
	}

	public class GameEventArgs : EventArgs
	{
		public Player Player { get; set; }
		public Player Enemy { get; set; }

		public GameResult Result { get; set; }
	}
	
	public class GameController : MonoBehaviour
	{
		[SerializeField]
		Player player;
		[SerializeField]
		Player enemy;
		[SerializeField] 
		GameSettings gameSettings;
		
		public event EventHandler<GameEventArgs> GameChanged;

		public SimpleGameControllerState State { get; private set; }

		int currentBet;
		GameEventArgs gameEventArgs;

		void Awake()
		{
			State = SimpleGameControllerState.Initializing;
		}

		void Start()
		{
			currentBet = gameSettings.initialBet;
			player.Initialize();
			enemy.Initialize();
			gameEventArgs = new GameEventArgs() {Enemy = enemy, Player = player};
			GameChanged?.Invoke(this, gameEventArgs);
			State = SimpleGameControllerState.WaitingInteraction;
			
		}

		public void HandlePlayerInput(int value)
		{
			Array choices = Enum.GetValues(typeof(HandChoice));
			HandChoice playerChoice = (HandChoice)choices.GetValue(value-1);
			
			player.SetHand(playerChoice);
			enemy.SetHand(GetEnemyChoice(choices));

			GameResult result = player.CurrentHand.Compare(enemy.CurrentHand);
			gameEventArgs.Result = result;
			UpdatePlayersCoins(result);
			GameChanged?.Invoke(this, gameEventArgs);
		}

		HandChoice GetEnemyChoice(Array choices)
		{
			//TODO Refactor
			int currentChoice = Random.Range(0, choices.Length);
			return (HandChoice)choices.GetValue(currentChoice);
		}
		
		void UpdatePlayersCoins (GameResult result)
		{
			switch (result)
			{
				case GameResult.Won:
					player.AddCoins(currentBet);
					enemy.AddCoins(-currentBet);
					break;
				case GameResult.Lost:
					player.AddCoins(-currentBet);
					enemy.AddCoins(currentBet);
					break;
			}
		}
	}
}