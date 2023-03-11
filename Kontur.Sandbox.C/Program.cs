var count = int.Parse(Console.ReadLine());
var teamScores = new SortedDictionary<string, int>();
while (count-- > 0)
{
	var teamScore = Console.ReadLine().Split(' ');
	teamScores.Add(teamScore[0], int.Parse(teamScore[1]));
}

var teams = Console.ReadLine().Split('-');
var leftTeam = teams[0];
var rightTeam = teams[1];

var result = new int[3];
result[0] = PlayGame(teamScores, 3, leftTeam, rightTeam);
teamScores[leftTeam] -= 3;
result[1] = PlayGame(teamScores, 1, leftTeam, rightTeam);
teamScores[leftTeam] -= 1;
teamScores[rightTeam] -= 1;
result[2] = PlayGame(teamScores, 0, leftTeam, rightTeam);

foreach (var gameResult in result)
{
	Console.WriteLine(gameResult);
}

int PlayGame(SortedDictionary<string, int> teamScores, int points, string leftTeam, string rightTeam)
{
	if (points == 3)
	{
		teamScores[leftTeam] += 3;
	}
	else if (points == 1)
	{
		teamScores[leftTeam] += 1;
		teamScores[rightTeam] += 1;
	}
	else
	{
		teamScores[rightTeam] += 3;
	}

	return teamScores
		.OrderByDescending(x => x.Value)
		.ToDictionary(key => key.Key, value => value.Value)
		.Keys.ToList()
		.IndexOf(leftTeam) + 1;
}