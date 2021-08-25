using System;
using UnityEngine;

namespace RockPaperScissors
{
	public abstract class UIPanel : MonoBehaviour
	{
		protected GameController Controller;

		void Awake()
		{
			Controller = FindObjectOfType<GameController>();
		}

		protected virtual void OnEnable()
		{
			Controller.GameStart += OnGameStart;
			Controller.GameChanged += OnGameChanged;
			Controller.GameOver += OnGameOver;
			Controller.RoundEnded += OnRoundEnded;
		}
		

		protected virtual void OnDisable()
		{
			Controller.GameChanged -= OnGameChanged;
			Controller.GameOver -= OnGameOver;
			Controller.RoundEnded -= OnRoundEnded;

		}
		
		protected virtual void OnGameStart() {}
		
		protected virtual void OnGameChanged(){}
		
		protected virtual void OnRoundEnded() {}
		
		protected virtual void OnGameOver(Player winner) {}
	}
}