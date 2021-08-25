using System;
using UnityEngine;

namespace RockPaperScissors
{
	public class GameController : MonoBehaviour
	{
		public event Action GameStart;
		public event Action GameChanged;
		public event Action RoundEnded;
		public event Action<Player> GameOver;

		public Player CurrentPlayer { get; private set; }

		public GameState State
		{
			get => _state;
			set
			{
				_state?.OnStateExit();
				_state = value;
				_state.OnStateEnter();
			}
		}

		public Player Player1 => player1;
		public Player Player2 => player2;

		public GameSettings Settings => gameSettings;
		public int CurrentBet => _currentBet;
		public int CurrentRound => _currentRound;


		[SerializeField] GameSettings gameSettings;
		[SerializeField] Player player1;
		[SerializeField] Player player2;

		int _currentBet;
		int _currentRound;
		GameState _state;

		void Start()
		{
			_currentBet = gameSettings.initialBet;
			_currentRound = 0;
			player1.Initialize();
			player2.Initialize();

			GameStart?.Invoke();
			StartRound();
		}
		
		public void Restart()
		{
			Start();
		}

		public void StartRound()
		{
			_currentRound++;
			SetCurrentPlayer(player1);
		}

		public void OnStateChanged()
		{
			GameChanged?.Invoke();
		}
		
		public void OnRoundEnd()
		{
			_currentRound = 0;
			GameChanged?.Invoke();
			RoundEnded?.Invoke();
		}
		
		public void EndGame()
		{
			Player winner;
			if (player1.Coins > 0)
				winner = player1;
			else
				winner = player2;

			GameOver?.Invoke(winner);
		}
		
		public void HandleInput(Player sender, HandChoice playerChoice)
		{
			sender.SetHand(playerChoice);

			if (sender == Player2)
			{
				State = new EndRoundState(this);
			}
			else
				SetCurrentPlayer(sender == player1 ? player2 : player1);
		}
		
		public void SetCurrentPlayer(Player newPlayer)
		{
			CurrentPlayer = newPlayer;
			State = new PlayerTurnState(this, newPlayer);
		}

		public void SetAutoMode(bool activate)
		{
			player1.SetControlled(activate);
			if (State.GetType() == typeof(WaitForInputState) && CurrentPlayer == player1)
				player1.Play(this);
		}

		public void AddBet(int bet)
		{
			_currentBet = Mathf.Clamp(_currentBet + bet, Settings.initialBet, Settings.maxBet);
			GameChanged?.Invoke();
		}
	}
}