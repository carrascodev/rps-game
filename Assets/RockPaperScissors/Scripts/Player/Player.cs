using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RockPaperScissors
{
	public class Player : MonoBehaviour
	{
		public string Name { get; private set; }
		public int Coins { get; private set; }
		
		public int Score {get; set;}
		
		public HandChoice CurrentHand { get; private set; }

		public PlayerInfo Info => info;
		public bool IsAI => _isAI;
		
		[SerializeField] 
		PlayerInfo info;
		
		bool _isAI;

		public virtual void Initialize()
		{
			Name = info.playerName;
			_isAI = info.isAi;
			Score = 0;
			Coins = info.startCoins;
		}

		public virtual void AddCoins(int amount)
		{
			Coins = Mathf.Clamp(Coins + amount,0, Int32.MaxValue);
		}
		
		public virtual void SetHand(HandChoice choice)
		{
			CurrentHand = choice;
		}

		public virtual void SetControlled(bool controlled)
		{
			_isAI = controlled;
		}

		public virtual void Play(GameController controller)
		{
			controller.State = new WaitForInputState(controller, this);
			
			if (_isAI)
			{
				Array choices = Enum.GetValues(typeof(HandChoice));
				int choiceIndex = Random.Range(0, choices.Length);
				ICommand command = new InputCommand(controller, (HandChoice) choices.GetValue(choiceIndex));
				command.Execute();	
			}
		}
	}
}