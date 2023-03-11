var input = Console.ReadLine();
var sorted = input.OrderBy(x => x).ToArray();
var minNumber = new string(sorted);
var maxNumber = new string(sorted.Reverse().ToArray());
Console.WriteLine(int.Parse(maxNumber) - int.Parse(minNumber));