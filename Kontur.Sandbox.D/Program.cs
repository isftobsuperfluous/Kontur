//int MaximalRectangle(char[][] matrix)
//{
//	var rows = matrix.Length;
//	var columns = matrix[0].Length;
//	var scheme = new string[rows];
//	for (int i = 0; i < rows; i++)
//	{
//		scheme[i] = new string(matrix[i]);
//	}
//	const char one = '1';
//	var max = 0;
//	for (int i = 0; i < rows; i++)
//	{
//		for (int j = 0; j < columns; j++)
//		{
//			if (scheme[i][j] == one)
//			{
//				max = GetMaxSize(scheme, i, j, max, 1);
//			}
//		}
//	}

//	return max;
//}

//int GetMaxSize(string[] scheme, int i, int j, int max, int rowLength)
//{
//	var rows = scheme.Length;
//	var columns = scheme[0].Length;
//	var currentSize = rowLength;
//	var row = i;
//	var line = new string('1', rowLength);
//	while (++row < rows && scheme[row].Substring(j, rowLength) == line)
//	{
//		currentSize += rowLength;
//	}

//	max = Math.Max(max, currentSize);
//	if (columns >= rowLength && columns > j + rowLength && scheme[i][j + rowLength] == '1')
//	{
//		max = GetMaxSize(scheme, i, j, max, rowLength + 1);
//	}

//	return max;
//}

//**********    // Для первого блока                              // Для второго блока
//*111*11** -> 1 max = 2       -> max = 4       -> max = 6            max = 4, 8, 6
//*111*11** -> 1 rowLength = 1 -> rowLength = 2 -> rowLength = 3    rowLength = 1, 2, 3
//*****111*
//*****111*
//**********

//**********
//*...******
//*........*
//*.......**
//**********
//*........*

//**********
//*...******
//*...******
//*..*******
//*..*******
//*..*******
//**********



// 250000 - 1996 = 23004
// ***** size = 25 max = 9 up = 5 down = 5 left = 3 right = 3 
// *...*
// *...*
// *...*
// *****

// 100 - 10 - 10 - 8 - 8 = 64
// **********
// *........*
// *........*
// *........*
// *........*
// *........*
// *........*
// *........*
// *........*
// **********

//var input = InputHelper.InputTest6();
//var rows = input.Rows;
//var columns = input.Columns;
//var scheme = input.Scheme;

//var size = Console.ReadLine().Split(' ');
//var rows = int.Parse(size[0]);
//var columns = int.Parse(size[1]);
//var scheme = new string[rows];

//for (int i = 0; i < rows; i++)
//{
//	scheme[i] = Console.ReadLine();
//}

//const char dot = '.';
//var max = 0;
//var rowLength = 0;
//var columnIndex = 0;
//var dictionary = new Dictionary<int, int>();
//for (int i = 1; i < rows - 1; i++)
//{
//	for (int j = 1; j < columns - 1; j++)
//	{
//		if (scheme[i][j] == dot)
//		{
//			max = GetMaxSize(scheme, i, j, max, 1);
//		}
//	}
//}

//Console.WriteLine(max);
//int GetMaxSize(string[] scheme, int i, int j, int max, int rowLength)
//{
//	var currentSize = rowLength;
//	var row = i;
//	var line = new string(dot, rowLength);
//	while (++row < rows && scheme[row].Substring(j, rowLength) == line)
//	{
//		currentSize += rowLength;
//	}

//	max = Math.Max(max, currentSize);
//	if (columns - 3 >= rowLength && scheme[i][j + rowLength] == dot)
//	{
//		dictionary.TryAdd(columnIndex, rowLength);
//		max = GetMaxSize(scheme, i, j, max, rowLength + 1);
//	}

//	return max;
//}

var size = Console.ReadLine().Split(' ', 2);
var rows = int.Parse(size[0]);
var cols = int.Parse(size[1]);
var matrix = new char[rows][];
for (int i = 0; i < rows; i++)
{
	var line = Console.ReadLine();
	matrix[i] = new char[cols];
	for (int j = 0; j < cols; j++)
	{
		matrix[i][j] = line[j];
	}
}

Console.WriteLine(MaximalRectangle(matrix));

int MaximalRectangle(char[][] matrix)
{
	var heights = new int[matrix[0].Length];
	var max = 0;
	for (int i = 1; i < matrix.Length - 1; i++)
	{
		for (int j = 1; j < matrix[0].Length - 1; j++)
		{
			if (matrix[i][j] == '*')
			{
				heights[j] = 0;
			}
			else
			{
				heights[j]++;
			}
		}

		max = Math.Max(max, LargestRectangleAreaTwoPointers(heights));
	}

	return max;
}

int LargestRectangleAreaTwoPointers(int[] heights)
{
	int[] lessFromLeft = new int[heights.Length];
	int[] lessFromRight = new int[heights.Length];
	lessFromRight[heights.Length - 1] = heights.Length;
	lessFromLeft[0] = -1;
	for (int i = 1; i < heights.Length; i++)
	{
		var left = i - 1;
		while (left >= 0 && heights[left] >= heights[i])
		{
			left = lessFromLeft[left];
		}
		lessFromLeft[i] = left;
	}
	for (var i = heights.Length - 2; i >= 0; i--)
	{
		var right = i + 1;
		while (right < heights.Length && heights[right] >= heights[i])
		{
			right = lessFromRight[right];
		}
		lessFromRight[i] = right;
	}

	var max = 0;
	for (int i = 0; i < heights.Length; i++)
	{
		max = Math.Max(max, heights[i] * (lessFromRight[i] - lessFromLeft[i] - 1));
	}

	return max;
}