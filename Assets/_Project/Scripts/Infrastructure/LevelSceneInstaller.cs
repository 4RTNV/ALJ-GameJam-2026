using _Project.MVVM;
using _Project.Services.Factory;
using Reflex.Core;
using UnityEngine;

namespace _Project.Infrastructure
{
    internal class LevelSceneInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddTransient(typeof(GameStateViewModel));

            containerBuilder.OnContainerBuilt += ContainerBuilt;
        }

        private void ContainerBuilt(Container obj)
        {
            var gameFactory = obj.Resolve<IGameFactory>();
            gameFactory.CreatePlayerUI(obj.Resolve<GameStateViewModel>());
            
        }
    }
}
