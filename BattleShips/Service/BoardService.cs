using BattleShips.Engines;
using Microsoft.Extensions.Caching.Memory;

namespace BattleShips.Service
{
    public class BoardService
    {
        private readonly IMemoryCache _cache;
        private const string PlayerBoardKey = "PlayerBoard";
        private const string ComputerBoardKey = "ComputerBoard";

        public BoardService(IMemoryCache cache)
        {
            _cache = cache;
            InitializeBoards();
        }

        public Board PlayerBoard
        {
            get => _cache.Get<Board>(PlayerBoardKey);
            private set => _cache.Set(PlayerBoardKey, value);
        }

        public Board ComputerBoard
        {
            get => _cache.Get<Board>(ComputerBoardKey);
            private set => _cache.Set(ComputerBoardKey, value);
        }

        private void InitializeBoards()
        {
            if (!_cache.TryGetValue(PlayerBoardKey, out Board playerBoard))
            {
                playerBoard = new Board();
                playerBoard.PlaceShipsRandomly();
                _cache.Set(PlayerBoardKey, playerBoard);
            }

            if (!_cache.TryGetValue(ComputerBoardKey, out Board computerBoard))
            {
                computerBoard = new Board();
                computerBoard.PlaceShipsRandomly();
                _cache.Set(ComputerBoardKey, computerBoard);
            }
        }

        public void ClearCache()
        {
            var emptyPlayerBoard = new Board();
            emptyPlayerBoard.PlaceShipsRandomly();
            _cache.Set(PlayerBoardKey, emptyPlayerBoard);

            var emptyComputerBoard = new Board();
            emptyComputerBoard.PlaceShipsRandomly();
            _cache.Set(ComputerBoardKey, emptyComputerBoard);
        }
    }

}

