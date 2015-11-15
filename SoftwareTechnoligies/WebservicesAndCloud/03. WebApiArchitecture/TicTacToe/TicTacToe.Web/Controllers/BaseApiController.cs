namespace TicTacToe.Web.Controllers
{
    using System.Web.Http;
    using Data;

    [Authorize]
    public abstract class BaseApiController : ApiController
    {
        protected ITicTacToeData data;

        public BaseApiController(ITicTacToeData data)
        {
            this.data = data;
        }
    }
}