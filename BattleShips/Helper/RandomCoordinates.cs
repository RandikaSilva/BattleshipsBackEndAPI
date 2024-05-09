using System;
namespace BattleShips.Helper
{
	public class RandomCoordinates
	{
		public RandomCoordinates()
		{
		}
        public static string GenerateRandomCoordinates()
        {
            Random random = new Random();
            char randomCol = (char)('A' + random.Next(10));
            int randomRow = random.Next(1, 11);
            return $"{randomCol}{randomRow}";
        }
    }
}

