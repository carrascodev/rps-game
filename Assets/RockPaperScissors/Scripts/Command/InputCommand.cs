namespace RockPaperScissors
{
	public class InputCommand : ICommand
	{
		GameController _controller;
		HandChoice _choice;

		public InputCommand(GameController controller, HandChoice choice)
		{
			_controller = controller;
			_choice = choice;
		}

		public void Execute()
		{
			var state = _controller.State as WaitForInputState;
			if(state != null)
				state.OnInputReceived(_choice);
		}
	}
}