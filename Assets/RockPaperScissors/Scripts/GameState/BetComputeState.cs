using System.Collections;
using UnityEngine;

namespace RockPaperScissors
{
	public class BetComputeState : GameState
	{
		public BetComputeState(GameController controller) : base(controller)
		{
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();
			Controller.StartCoroutine(ComputeResult());
		}

		public override void OnStateExit()
		{
			base.OnStateExit();
			Controller.Player1.Score = 0;
			Controller.Player2.Score = 0;
		}

		IEnumerator ComputeResult()
		{
			GameResult result = GameResult.Lost;
			if (Controller.Player1.Score > Controller.Player2.Score)
				result = GameResult.Won;
			else if (Controller.Player1.Score == Controller.Player2.Score)
				result = GameResult.Draw;
			
			Controller.OnRoundEnd();
			UpdatePlayersCoins(result);
			
			yield return Controller.Settings.DefaultStateDelay;
			
			if (Controller.Player1.Coins <= 0 || Controller.Player2.Coins <= 0)
				Controller.State = new EndGameState(Controller);
			else
				Controller.StartRound();
		}


		void UpdatePlayersCoins (GameResult result)
		{
			var bet = Controller.CurrentBet;
			switch (result)
			{
				case GameResult.Won:
					Controller.Player1.AddCoins(bet);
					Controller.Player2.AddCoins(-bet);
					break;
				case GameResult.Lost:
					Controller.Player1.AddCoins(-bet);
					Controller.Player2.AddCoins(bet);
					break;
			}
		}
	}
}