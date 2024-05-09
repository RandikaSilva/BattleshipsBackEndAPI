namespace BattleShips.Engines
{
    public class Board
    {
        private char[,] board = new char[10, 10];
        private Random random = new Random();
        private HashSet<string> firedCoordinatesforuser = new HashSet<string>();
        private HashSet<string> firedCoordinatesforcomputer = new HashSet<string>();

        public void PlaceShipsRandomly()
        {
            PlaceShip(5);
            PlaceShip(4);
            PlaceShip(4);
        }

        private void PlaceShip(int size)
        {
            bool placed = false;
            while (!placed)
            {
                int row = random.Next(0, 10);
                int col = random.Next(0, 10);
                bool vertical = random.Next(0, 2) == 0;
                if (CanPlaceShip(row, col, vertical, size))
                {
                    if (vertical)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            board[row + i, col] = 'S';
                        }
                    }
                    else
                    {
                        for (int i = 0; i < size; i++)
                        {
                            board[row, col + i] = 'S';
                        }
                    }
                    placed = true;
                }
            }
        }

        private bool CanPlaceShip(int row, int col, bool vertical, int size)
        {
            if (vertical && row + size > 10)
                return false;
            if (!vertical && col + size > 10)
                return false;

            for (int i = 0; i < size; i++)
            {
                if (vertical && board[row + i, col] != '\0')
                    return false;
                if (!vertical && board[row, col + i] != '\0')
                    return false;
            }

            return true;
        }

        public bool ValidateCoordinates(string coordinates, string userType)
        {
            if (coordinates.Length < 2 || coordinates.Length > 3)
                return false;

            char[] validLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            char[] validDigits = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            char colChar = coordinates[0];
            char rowChar = coordinates[coordinates.Length - 1];

            if (!validLetters.Contains(colChar) || !validDigits.Contains(rowChar))
                return false;

            int row;
            if (!int.TryParse(coordinates.Substring(1), out row))
                return false;

            if (row < 1 || row > 10)
                return false;

            if (userType == "computer")
            {
                if (firedCoordinatesforcomputer.Contains(coordinates))
                    return false;
            }
            else
            {
                if (firedCoordinatesforuser.Contains(coordinates))
                    return false;
            }

            return true;
        }

        public bool FireShot(string coordinates, string userType)
        {
            if (!ValidateCoordinates(coordinates, userType))
                return false;

            char colChar = coordinates[0];
            int col = colChar - 'A';

            int row;
            if (!int.TryParse(coordinates.Substring(1), out row))
                return false;

            row--;

            char target = board[row, col];
            if (target == 'S')
            {
                board[row, col] = 'X';
            }
            else
            {
                board[row, col] = 'O';
            }
            if (userType == "computer")
            {
                firedCoordinatesforcomputer.Add(coordinates);
            }
            else
            {
                firedCoordinatesforuser.Add(coordinates);
            }

            return true;
        }


        public bool AllShipsSunk()
        {
            foreach (char cell in board)
            {
                if (cell == 'S')
                    return false;
            }
            return true;
        }

        public char[,] GetBoardState()
        {
            return board;
        }

        public char[,] GetOpponentBoardState()
        {
            char[,] opponentBoard = (char[,])board.Clone();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (opponentBoard[i, j] == 'S')
                        opponentBoard[i, j] = '\0';
                }
            }
            return opponentBoard;
        }
    }

}

