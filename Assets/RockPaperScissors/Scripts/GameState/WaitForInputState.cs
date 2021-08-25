namespace RockPaperScissors
{
	public class WaitForInputState : GameState
	{
		Player _player;

		public WaitForInputState(GameController controller, Player player) : base(controller)
		{
			_player = player;
		}
		
		public void OnInputReceived(HandChoice choice)
		{
			if(Controller.CurrentPlayer == _player)
				Controller.HandleInput(_player, choice);
		}
	}
}