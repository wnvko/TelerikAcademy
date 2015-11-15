using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Web.Infrastructure
{
    public interface IUserIdProvider
    {
        string GetUserId();
    }
}
