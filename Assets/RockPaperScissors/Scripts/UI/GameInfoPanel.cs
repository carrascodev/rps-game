using System;
using UnityEngine;
using UnityEngine.UI;

namespace RockPaperScissors
{
	public class GameInfoPanel : UIPanel
	{
		[Header("Player1")] [SerializeField] Text player1Name;
		[SerializeField] Text player1Hand;
		[SerializeField] Text player1HandLabel;
		[SerializeField] Text player1Coins;
		[SerializeField] Text player1Score;


		[Header("Player2")] [SerializeField] Text player2Name;
		[SerializeField] Text player2Hand;
		[SerializeField] Text player2HandLabel;
		[SerializeField] Text player2Coins;
		[SerializeField] Text player2Score;
		
		[SerializeField] Text gameOverLabel;

		[SerializeField] Button restartButton;

		protected override void OnEnable()
		{
			base.OnEnable();
			restartButton.onClick.AddListener(() => Controller.Restart());
		}
		
		protected override void OnDisable()
		{
			base.OnDisable();
			restartButton.onClick.RemoveAllListeners();
		}

		protected override void OnGameStart()
		{
			player1Name.text = Controller.Player1.Name;
			player1HandLabel.text = Controller.Player1.Name + " Hand";
			
			player2Name.text = Controller.Player2.Name;
			player2HandLabel.text = Controller.Player2.Name + " Hand";

			gameOverLabel.text = "";
		}
		
		protected override void OnGameChanged()
		{
			player1Coins.text = $"Money: ${Controller.Player1.Coins.ToString()}";
			player1Score.text = $"Score: {Controller.Player1.Score.ToString()}";
			
			player2Coins.text = $"Money: ${Controller.Player2.Coins.ToString()}";
			player2Score.text = $"Score: {Controller.Player2.Score.ToString()}";
		}

		protected override void OnRoundEnded()
		{
			player1Hand.text = Controller.Player1.CurrentHand.ToString();
			player2Hand.text = Controller.Player2.CurrentHand.ToString();
		}

		protected override void OnGameOver(Player winner)
		{
			gameOverLabel.text = $"Winner is {winner.Name}";
			gameOverLabel.color = winner.Info.playerColor;
		}


	}
}