using BattleShips.Helper;
using BattleShips.Service;
using Microsoft.AspNetCore.Mvc;

namespace BattleShips
{
    [ApiController]
    [Route("[controller]")]
    public class BattleShipsController : ControllerBase
    {
        private readonly BoardService _boardService;

        public BattleShipsController(BoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet("re-player")]
        public ActionResult<char[][]> GetReplayPlayerBoardState()
        {
            _boardService.ClearCache();
            var boardState = _boardService.PlayerBoard.GetBoardState();
            var jaggedArray = Converters.ConvertToJaggedArray(boardState);
            return Ok(jaggedArray);
        }

        [HttpGet("player-board")]
        public ActionResult<char[][]> GetPlayerBoardState()
        {
            var boardState = _boardService.PlayerBoard.GetBoardState();
            var jaggedArray = Converters.ConvertToJaggedArray(boardState);
            return Ok(jaggedArray);
        }

        [HttpGet("computer-board")]
        public ActionResult<char[][]> GetComputerBoardState()
        {
            var boardState = _boardService.ComputerBoard.GetOpponentBoardState();
            var jaggedArray = Converters.ConvertToJaggedArray(boardState);
            return Ok(jaggedArray);
        }

        [HttpPost("fire-shot")]
        public ActionResult FireShot([FromBody] string coordinates)
        {
            if (string.IsNullOrWhiteSpace(coordinates))
            {
                return BadRequest("Coordinates cannot be empty.");
            }

            try
            {
                if (_boardService.PlayerBoard.ValidateCoordinates(coordinates,"user"))
                {
                    var playerResult = _boardService.ComputerBoard.FireShot(coordinates,"user");

                    if (_boardService.ComputerBoard.AllShipsSunk())
                    {
                        return Ok(new { PlayerResult = playerResult, GameOver = true, Message="Player Wins" });
                    }

                    var computerResult = false;
                    do
                    {
                        var computerCoordinates = RandomCoordinates.GenerateRandomCoordinates();
                        computerResult = _boardService.PlayerBoard.FireShot(computerCoordinates,"computer");

                    } while (!computerResult);

                    if (_boardService.PlayerBoard.AllShipsSunk())
                    {
                        return Ok(new { PlayerResult = playerResult, GameOver = true, Message = "Computer Wins" });
                    }
                    return Ok(new { PlayerResult = playerResult, ComputerResult = computerResult, Message = "Shot fired successfully." });
                }
                else
                {
                    return BadRequest("Invalid coordinates or coordinates already fired.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
