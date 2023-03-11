var count = int.Parse(Console.ReadLine());
var array = new int[count];
int i = 0;
while (count-- > 0)
{
	array[i++] = int.Parse(Console.ReadLine());
}

Console.WriteLine(-array.Sum());