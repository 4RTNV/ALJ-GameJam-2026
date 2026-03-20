using _Project.Infrastructure.GameTime;
using _Project.Services.Factory;
using _Project.UI.ViewModels;
using _Project.Interactables;
using Reflex.Core;
using UnityEngine;

namespace _Project.Infrastructure
{
    internal class LevelSceneInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddTransient(typeof(GameStateViewModel));
            containerBuilder.AddTransient(typeof(PlayerInventoryViewModel));
            containerBuilder.AddTransient(typeof(TooltipViewModel));

            containerBuilder.OnContainerBuilt += ContainerBuilt;
        }

        private void ContainerBuilt(Container obj)
        {
            var gameFactory = obj.Resolve<IGameFactory>();
            var ui = gameFactory.CreatePlayerUI(obj.Resolve<GameStateViewModel>());

            obj.Resolve<IGameTimer>().IsActive = true; //DONT MERGE ME TO MAIN
        }
    }
}
