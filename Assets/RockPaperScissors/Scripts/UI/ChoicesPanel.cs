using UnityEngine;
using UnityEngine.UI;

namespace RockPaperScissors
{
	public class ChoicesPanel : UIPanel
	{
		[SerializeField] Button rockButton;
		[SerializeField] Button paperButton;
		[SerializeField] Button scissorsButton;


		protected override void OnEnable()
		{
			base.OnEnable();
			rockButton.onClick.AddListener(() => HandleInput(HandChoice.Rock));
			paperButton.onClick.AddListener(() => HandleInput(HandChoice.Paper));
			scissorsButton.onClick.AddListener(() => HandleInput(HandChoice.Scissors));
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			rockButton.onClick.RemoveAllListeners();
			paperButton.onClick.RemoveAllListeners();
			scissorsButton.onClick.RemoveAllListeners();
		}

		protected override void OnGameChanged()
		{
			base.OnGameChanged();
			
			Color currentColor = Controller.CurrentPlayer.Info.playerColor;
			rockButton.image.color = currentColor;
			paperButton.image.color = currentColor;
			scissorsButton.image.color = currentColor;
			
			bool isAi = !Controller.CurrentPlayer.IsAI;
			rockButton.interactable = isAi;
			paperButton.interactable = isAi;
			scissorsButton.interactable = isAi;
		}
		
		void HandleInput(HandChoice choice)
		{
			ICommand command = new InputCommand(Controller, choice);
			command.Execute();
		}
	}
}