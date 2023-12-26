using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPGClash.GameEngine.CharacterAction.Abstract;
using RPGClash.GameEngine.CharacterAction.Concrete;
using RPGClash.GameEngine.Game.Abstract;
using RPGClash.GameEngine.Game.Concrete;
using RPGClash.GameEngine.GameProcess.Abstract;
using RPGClash.GameEngine.GameProcess.Concrete;

namespace RPGClash.GameEngine
{
    public static class GameEngineExtentions
    {
        public static IServiceCollection AddGameEngine(this IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            services.AddSingleton<IActionClassMapperService, ActionClassMapperService>();
            services.AddSingleton<IActionsManager, ActionsManager>();
            services.AddSingleton<IGameProcessManager, GameProcessManager>();
            services.AddSingleton<IGameStateManager, GameStateManager>();

            return services;
        }
    }
}
