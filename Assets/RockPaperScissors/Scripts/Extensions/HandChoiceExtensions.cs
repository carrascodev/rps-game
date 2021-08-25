namespace RockPaperScissors
{
	public static class HandChoiceExtensions
	{
		public static GameResult Compare(this HandChoice current, HandChoice other)
		{
			if (current == other)
				return GameResult.Draw;

			switch (current)
			{
				case HandChoice.Rock when other == HandChoice.Scissors:
				case HandChoice.Paper when other == HandChoice.Rock:
				case HandChoice.Scissors when other == HandChoice.Paper:
					return GameResult.Won;
				default:
					return GameResult.Lost;
			}
		}
	}
}