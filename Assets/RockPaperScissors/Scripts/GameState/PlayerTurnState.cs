using System;
using Random = UnityEngine.Random;

namespace RockPaperScissors
{
	public class PlayerTurnState : GameState
	{
		Player _player;

		public PlayerTurnState(GameController controller, Player player) : base(controller)
		{
			_player = player;
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();
			_player.Play(Controller);
		}
	}
}