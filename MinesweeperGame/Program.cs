using Microsoft.Extensions.DependencyInjection;
using Minesweeper.Constant;
using Minesweeper.Interfaces;
using Minesweeper.Model;
using Minesweeper.Repository;
using System;
using static Minesweeper.Constant.MineSweeperContant;

namespace Minesweeper
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var game = serviceProvider.GetService<IGame>();
            game?.Start();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            ConfigureGameServices(services);
            return services.BuildServiceProvider();
        }

        private static void ConfigureGameServices(IServiceCollection services)
        {
            services.AddSingleton<IGame, Game>();
            services.AddSingleton<IMineRepository, MineRepository>();
            services.AddSingleton<IBoard, Board>(provider =>
            {
                var mineRepository = provider.GetService<IMineRepository>();
                var mines = mineRepository?.GetMines();

                return new Board(GameConstants.BoardWidth, GameConstants.BoardHeight, mines);
            });
            services.AddSingleton<IPlayer, Player>(provider => new Player(PlayerLocation.Default_X, PlayerLocation.Default_Y, GameConstants.PlayerLives));
        }
    }
}