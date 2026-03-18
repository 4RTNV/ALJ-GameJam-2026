using _Project.Services.Factory;
using _Project.UI.ViewModels;
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

            containerBuilder.OnContainerBuilt += ContainerBuilt;
        }

        private void ContainerBuilt(Container obj)
        {
            var gameFactory = obj.Resolve<IGameFactory>();
            gameFactory.CreatePlayerUI(obj.Resolve<GameStateViewModel>());
            
        }
    }
}
