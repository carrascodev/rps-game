using System;
using UnityEngine;
using UnityEngine.UI;

namespace JoKenPo.UI
{
	public class UIGameFrame : MonoBehaviour
	{
		[SerializeField]
		Text playerHand;
		[SerializeField]
		Text enemyHand;

		[SerializeField] 
		Text playerCoins;
		[SerializeField] 
		Text enemyCoins;

		[SerializeField] 
		Text playerName;
		[SerializeField] 
		Text enemyName;

		[SerializeField]
		GameController controller;

		void OnEnable()
		{
			controller.GameChanged += OnGameChanged;
		}
		
		void OnDisable()
		{
			controller.GameChanged -= OnGameChanged;
		}
		
		void OnGameChanged(object sender, GameEventArgs args)
		{
			playerName.text = args.Player.Name;
			enemyName.text = args.Enemy.Name;
			playerCoins.text = $"Money: ${args.Player.Coins.ToString()}";
			enemyCoins.text = $"Money: ${args.Enemy.Coins.ToString()}";
			
			if (args.Result != GameResult.None)
			{
				playerHand.text = args.Player.CurrentHand.ToString();
				enemyHand.text = args.Enemy.CurrentHand.ToString();
			}
		}
	}
}