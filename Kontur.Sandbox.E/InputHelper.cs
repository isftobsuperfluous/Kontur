namespace Kontur.Sandbox.E
{
	internal static class InputHelper
	{
		public static (int FirstDayBuildings, List<string> Addresses, int Postings, List<string> Streets) Input()
		{
			var firstDayBuildings = 3;
			var addresses = new List<string>() { "mira32", "turgeneva4", "mira1" };
			var postings = 6;
			var streets = new List<string>() { "mira", "turgeneva", "turgeneva", "turgeneva", "turgeneva", "lenina" };

			return (firstDayBuildings, addresses, postings, streets);
		}
	}
}
