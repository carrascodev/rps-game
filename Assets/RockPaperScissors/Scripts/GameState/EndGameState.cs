namespace RockPaperScissors
{
	public class EndGameState : GameState
	{
		public EndGameState(GameController controller) : base(controller)
		{
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();
			Controller.EndGame();
		}
	}
}