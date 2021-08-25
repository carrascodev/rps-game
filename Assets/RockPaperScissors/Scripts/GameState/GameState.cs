 namespace RockPaperScissors
 {
	 public abstract class GameState
 	{

 		protected GameController Controller;
 		public GameState(GameController controller)
        {
	        Controller = controller;
        }
 		
 		public virtual void OnStateEnter()
 		{
 			Controller.OnStateChanged();
 		}

 		public virtual void OnStateExit()
 		{
 			
 		}
    }
 }