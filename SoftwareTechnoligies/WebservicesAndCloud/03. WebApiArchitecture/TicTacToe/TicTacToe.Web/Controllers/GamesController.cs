namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Web.Http;
    using Data;
    using DataModels;
    using GameLogic;
    using Infrastructure;
    using TicTacToe.Models;

    public class GamesController : BaseApiController
    {
        private IGameResultValidator resultValidator;
        private IUserIdProvider userIdProvider;

        public GamesController(
            ITicTacToeData data,
            IGameResultValidator resultValidator,
            IUserIdProvider userIdProvider) : base(data)
        {
            this.resultValidator = resultValidator;
            this.userIdProvider = userIdProvider;
        }

        [HttpPost]
        public IHttpActionResult Create()
        {
            var currentUserId = this.userIdProvider.GetUserId();
            var newGame = new Game()
            {
                FirstPlayerId = currentUserId,
            };

            this.data.Games.Add(newGame);
            this.data.SaveChages();

            return Ok(newGame.Id.ToString());
        }

        [HttpPost]
        public IHttpActionResult Join()
        {
            var currentUserId = this.userIdProvider.GetUserId();
            var game = this.data.Games
                .All()
                .Where(g => g.State == GameState.WaitingForSecondPlayer && g.FirstPlayerId != currentUserId)
                .FirstOrDefault();

            if (game == null)
            {
                return NotFound();
            }

            game.SecondPlayerId = currentUserId;
            game.State = GameState.TurnX;
            this.data.SaveChages();

            return Ok(game.Id);
        }

        [HttpGet]
        public IHttpActionResult Status(string gameId)
        {
            var currentUserId = this.userIdProvider.GetUserId();
            var gameIdAsGuid = new Guid(gameId);
            var game = this.data.Games
                .All()
                .Where(g => g.Id == gameIdAsGuid)
                .Select(g => new
                {
                    FirstPlayerId = g.FirstPlayerId,
                    SecondPlayerId = g.SecondPlayerId
                })
                .FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }

            if (game.FirstPlayerId != currentUserId &&
                game.SecondPlayerId != currentUserId)
            {
                return this.BadRequest("This is not your game!");
            }

            var gameInfo = this.data.Games
                .All()
                .Where(g => g.Id == gameIdAsGuid)
                .Select(g => new GameInfoDataModel
                {
                    Board = g.Board,
                    Id = g.Id,
                    FirstPlayerName = g.FirstPlayer.UserName,
                    SecondPlayerName = g.SecondPlayer.UserName,
                    State = g.State,
                })
                .FirstOrDefault();

            return Ok(gameInfo);
        }

        [HttpPost]
        public IHttpActionResult Play(PlayerReguestDataModel request)
        {
            if (request == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var currentUserId = this.userIdProvider.GetUserId();
            var gameIdAsGuid = new Guid(request.GameId);
            var game = this.data.Games.Find(gameIdAsGuid);

            if (game == null)
            {
                return this.BadRequest("Invalid game Id!");
            }

            if (game.FirstPlayerId != currentUserId &&
                game.SecondPlayerId != currentUserId)
            {
                return this.BadRequest("This is not your game!");
            }

            if (game.State != GameState.TurnO && game.State != GameState.TurnX)
            {
                return this.BadRequest("Invalid state!");
            }

            if ((game.State == GameState.TurnX && game.FirstPlayerId != currentUserId) ||
                (game.State == GameState.TurnO && game.SecondPlayerId != currentUserId))
            {
                return this.BadRequest("It's not your turn!");
            }

            var positionIndex = (request.Row - 1) * 3 + request.Col - 1;
            if (game.Board[positionIndex] != '-')
            {
                return this.BadRequest("Invalid position!");
            }

            var boardAsStringBuilder = new StringBuilder(game.Board);
            boardAsStringBuilder[positionIndex] = game.State == GameState.TurnX ? 'X' : 'O';
            game.Board = boardAsStringBuilder.ToString();

            game.State = game.State == GameState.TurnX ? GameState.TurnO : GameState.TurnX;
            this.data.SaveChages();

            var gameResult = this.resultValidator.GetResult(game.Board);
            switch (gameResult)
            {
                case GameResult.NotFinished:
                    break;
                case GameResult.WonByX:
                    game.State = GameState.WonByX;
                    this.data.SaveChages();
                    break;
                case GameResult.WonByO:
                    game.State = GameState.WonByO;
                    this.data.SaveChages();
                    break;
                case GameResult.Draw:
                    game.State = GameState.Draw;
                    this.data.SaveChages();
                    break;
                default:
                    break;
            }
            return this.Ok();
        }
    }
}