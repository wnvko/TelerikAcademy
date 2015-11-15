namespace TicTacToe.Data
{
    using System;
    using Repositories;
    using Models;

    public interface ITicTacToeData
    {
        IRepository<User> Users { get;}

        IRepository<Game> Games { get;}

        int SaveChages();
    }
}
