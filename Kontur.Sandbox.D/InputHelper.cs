namespace Kontur.Sandbox.D
{
	internal static class InputHelper
	{
		// 8
		public static (int Rows, int Columns, string[] Scheme) InputFirstTest()
		{
			var rows = 4;
			var columns = 10;
			var scheme = new string[rows];
			scheme[0] = new string('*', columns);
			scheme[1] = "*...*....*";
			scheme[2] = "*...*....*";
			scheme[3] = new string('*', columns);

			return (rows, columns, scheme);
		}

		// 0
		public static (int Rows, int Columns, string[] Scheme) InputSecondTest()
		{
			var rows = 3;
			var columns = 3;
			var scheme = new string[rows];
			scheme[0] = new string('*', columns);
			scheme[1] = new string('*', columns);
			scheme[2] = new string('*', columns);

			return (rows, columns, scheme);
		}

		// 0
		public static (int Rows, int Columns, string[] Scheme) InputTest1()
		{
			var rows = 3;
			var columns = 1;
			var scheme = new string[rows];
			scheme[0] = new string('*', columns);
			scheme[1] = new string('*', columns);
			scheme[2] = new string('*', columns);

			return (rows, columns, scheme);
		}

		// 1
		public static (int Rows, int Columns, string[] Scheme) InputTest2()
		{
			var rows = 3;
			var columns = 3;
			var scheme = new string[rows];
			scheme[0] = new string('*', columns);
			scheme[1] = "*.*";
			scheme[2] = new string('*', columns);

			return (rows, columns, scheme);
		}

		// 2
		public static (int Rows, int Columns, string[] Scheme) InputTest3()
		{
			var rows = 5;
			var columns = 5;
			var scheme = new string[rows];
			scheme[0] = new string('*', columns);
			scheme[1] = "**.**";
			scheme[2] = "*****";
			scheme[3] = "**..*";
			scheme[4] = new string('*', columns);

			return (rows, columns, scheme);
		}

		// 64
		public static (int Rows, int Columns, string[] Scheme) InputTest4()
		{
			var rows = 10;
			var columns = 10;
			var scheme = new string[rows];
			scheme[0] = new string('*', columns);
			scheme[1] = "*........*";
			scheme[2] = "*........*";
			scheme[3] = "*........*";
			scheme[4] = "*........*";
			scheme[5] = "*........*";
			scheme[6] = "*........*";
			scheme[7] = "*........*";
			scheme[8] = "*........*";
			scheme[9] = new string('*', columns);

			return (rows, columns, scheme);
		}

		// 0
		public static (int Rows, int Columns, string[] Scheme) InputTest5()
		{
			var rows = 3;
			var columns = 1;
			var scheme = new string[rows];
			scheme[0] = "*";
			scheme[1] = "*";
			scheme[2] = "*";

			return (rows, columns, scheme);
		}

		// 10
		public static (int Rows, int Columns, string[] Scheme) InputTest6()
		{
			var rows = 7;
			var columns = 10;
			var scheme = new string[rows];
			scheme[0] = new string('*', columns);
			scheme[1] = "*...******";
			scheme[2] = "*...******";
			scheme[3] = "*..*******";
			scheme[4] = "*..*******";
			scheme[5] = "*..*******";
			scheme[6] = new string('*', columns);

			return (rows, columns, scheme);
		}

		public static (int Rows, int Columns, string[] Scheme) InputTest7()
		{
			var rows = 7;
			var columns = 10;
			var scheme = new string[rows];
			scheme[0] = new string('*', columns);
			scheme[1] = "*........*";
			scheme[2] = "**********";
			scheme[3] = "**********";
			scheme[4] = "**********";
			scheme[5] = "**********";
			scheme[6] = new string('*', columns);

			return (rows, columns, scheme);
		}
	}
}
