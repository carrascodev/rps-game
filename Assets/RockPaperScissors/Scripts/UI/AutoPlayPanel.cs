using UnityEngine;
using UnityEngine.UI;

namespace RockPaperScissors
{
	public class AutoPlayPanel : UIPanel
	{
		[SerializeField] Button autoButton;

		[SerializeField] Button betPlusButton;
		[SerializeField] Button betMinusButton;
		[SerializeField] Text betLabel;

		protected override void OnEnable()
		{
			SetButtonsActive(false);
			
			base.OnEnable();
			autoButton.onClick.AddListener(AutoModeChange);
			betPlusButton.onClick.AddListener(() => Controller.AddBet(10));
			betMinusButton.onClick.AddListener(() => Controller.AddBet(-10));
		}

		
		protected override void OnDisable()
		{
			base.OnDisable();
			autoButton.onClick.RemoveAllListeners();
			betPlusButton.onClick.RemoveAllListeners();
			betMinusButton.onClick.RemoveAllListeners();
		}

		protected override void OnGameStart()
		{
			Text autoText = autoButton.GetComponentInChildren<Text>();
			autoText.text = Controller.Player1.IsAI ? "END" : "AUTO";
			SetButtonsActive(true);
		}

		protected override void OnGameChanged()
		{
			betLabel.text = $"Current Bet: {Controller.CurrentBet.ToString()}";
		}

		protected override void OnGameOver(Player winner)
		{
			base.OnGameOver(winner);
			SetButtonsActive(false);
		}

		void AutoModeChange()
		{
			Controller.SetAutoMode(!Controller.Player1.IsAI);
			Text autoText = autoButton.GetComponentInChildren<Text>();
			autoText.text = Controller.Player1.IsAI ? "END" : "AUTO";
		}

		void SetButtonsActive(bool interactable)
		{
			autoButton.interactable = interactable;
			betPlusButton.interactable = interactable;
			betMinusButton.interactable = interactable;
		}
	}
}