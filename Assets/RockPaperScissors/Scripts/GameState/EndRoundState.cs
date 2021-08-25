using System.Collections;
using RockPaperScissors;
using UnityEngine;

namespace RockPaperScissors
{
	public class EndRoundState : GameState
	{
		public EndRoundState(GameController controller) : base(controller)
		{
		}

		public override void OnStateEnter()
		{
			Controller.StartCoroutine(ComputeRoundResult());
		}

		public IEnumerator ComputeRoundResult()
		{
			GameResult roundResult = Controller.Player1.CurrentHand.Compare(Controller.Player2.CurrentHand);

			if (roundResult == GameResult.Won)
				Controller.Player1.Score++;
			else if (roundResult == GameResult.Lost)
				Controller.Player2.Score++;

			Controller.OnStateChanged();
			Controller.OnRoundEnd();
			yield return Controller.Settings.DefaultStateDelay;//TODO: cache this

			if (Controller.CurrentRound >= Controller.Settings.rule.NumberOfRounds
			    || Controller.Player1.Score >= Controller.Settings.rule.RoundsToWin
			    || Controller.Player2.Score >= Controller.Settings.rule.RoundsToWin)
				Controller.State = new BetComputeState(Controller);
			else
				Controller.StartRound();
		}
	}
}