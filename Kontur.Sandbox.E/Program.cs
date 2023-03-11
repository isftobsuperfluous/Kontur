// Simplify input

//using Kontur.Sandbox.E;

//var input = InputHelper.Input();
//var firstDayBuildings = input.FirstDayBuildings;
//var addresses = input.Addresses;
//var postings = input.Postings;
//var streets = input.Streets;

var firstDayBuildings = int.Parse(Console.ReadLine()!);
var addressesStorage = new Dictionary<string, int[]>();
for (int i = 0; i < firstDayBuildings; i++)
{
	//var address = addresses[i];
	var address = Console.ReadLine()!;
	var j = address.Length - 1;
	while (char.IsDigit(address[j]))
	{
		j--;
	}

	var street = new string(address.Take(j + 1).ToArray());
	var homeNumber = int.Parse(new string(address.Skip(j + 1).Take(address.Length - j - 1).ToArray()));
	if (!addressesStorage.ContainsKey(street))
	{
		addressesStorage.Add(street, new int[300_000 / firstDayBuildings]);
		addressesStorage[street][homeNumber] = homeNumber;
	}
	else
	{
		var index = IndexOfSecondZero(addressesStorage[street]).next;
		addressesStorage[street][index] = index;
	}
}


var resultHomeNumber = new List<int>();
var postings = int.Parse(Console.ReadLine()!);
var nextNextZero = -1;
for (int i = 0; i < postings; i++)
{
	//var secondDayStreet = streets[i];
	var secondDayStreet = Console.ReadLine()!;
	var zeroIndexStorage = new Dictionary<string, int>();
	if (addressesStorage.ContainsKey(secondDayStreet))
	{
		int nextZero;
		if (zeroIndexStorage.ContainsKey(secondDayStreet) && zeroIndexStorage[secondDayStreet] != -1)
		{
			nextZero = zeroIndexStorage[secondDayStreet];
		}
		else
		{
			var indexes = IndexOfSecondZero(addressesStorage[secondDayStreet]);
			nextZero = indexes.next;
			nextNextZero = indexes.nextNext;
		}
		if (!zeroIndexStorage.TryAdd(secondDayStreet, nextNextZero))
		{
			zeroIndexStorage[secondDayStreet] = nextNextZero;
		}
		if (nextZero != -1)
		{
			addressesStorage[secondDayStreet][nextZero] = nextZero;
			resultHomeNumber.Add(nextZero);
		}
		else if (nextZero - 1 >= addressesStorage[secondDayStreet].Length)
		{
			addressesStorage[secondDayStreet] = ReInitArray(addressesStorage[secondDayStreet], addressesStorage[secondDayStreet].Length * 2, false);
		}
		else
		{
			resultHomeNumber.Add(addressesStorage[secondDayStreet].Length);
			addressesStorage[secondDayStreet] = ReInitArray(addressesStorage[secondDayStreet], addressesStorage[secondDayStreet].Length * 2, false);
		}
	}
	else
	{
		addressesStorage.Add(secondDayStreet, new int[2]);
		addressesStorage[secondDayStreet][1] = 1;
		resultHomeNumber.Add(1);
	}
}

resultHomeNumber.ForEach(x => Console.WriteLine(x));

int[] ReInitArray(int[] array, int homeNumber, bool setValue)
{
	var newArray = new int[homeNumber * 2];
	for (int i = 0; i < array.Length; i++)
	{
		newArray[i] = array[i];
	}

	if (setValue)
	{
		newArray[homeNumber] = homeNumber;
	}
	else
	{
		newArray[array.Length] = array.Length;
	}

	return newArray;
}

(int next, int nextNext) IndexOfSecondZero(int[] array)
{
	var next = -1;
	var count = 1;
	var nextNext = -1;
	for (int i = 1; i < array.Length; i++)
	{
		if (array[i] == 0 && count == 1)
		{
			next = i;
			count++;
		}
		else if (array[i] == 0 && count == 2)
		{
			nextNext = i;
		}
	}

	return (next, nextNext);
}