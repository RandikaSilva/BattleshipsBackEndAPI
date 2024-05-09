using System;
namespace BattleShips.Helper
{
	public class Converters
	{
		public Converters()
		{
		}

        public static char[][] ConvertToJaggedArray(char[,] boardState)
        {
            var jaggedArray = new char[boardState.GetLength(0)][];
            for (int i = 0; i < boardState.GetLength(0); i++)
            {
                jaggedArray[i] = new char[boardState.GetLength(1)];
                for (int j = 0; j < boardState.GetLength(1); j++)
                {
                    jaggedArray[i][j] = boardState[i, j];
                }
            }
            return jaggedArray;
        }
    }
}

