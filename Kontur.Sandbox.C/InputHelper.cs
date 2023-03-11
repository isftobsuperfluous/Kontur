namespace Kontur.Sandbox.C
{
	internal static class InputHelper
	{
		public static (int Count, SortedDictionary<string, int> TeamScores, string Pair) Input()
		{
			var count = 7;
			var teamScores = new SortedDictionary<string, int>
			{
				{"ZENIT", 65},
				{"SOCHI", 56},
				{"DINAMO", 53},
				{"CSKA", 50},
				{"KRASNODAR", 49},
				{"LOKOMOTIV", 48},
				{ "AKHMAT", 41}
			};
			var pair = "KRASNODAR-AKHMAT";

			return (count, teamScores, pair);
		}
	}
}
