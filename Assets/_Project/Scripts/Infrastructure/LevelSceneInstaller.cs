using _Project.Infrastructure.GameTime;
using _Project.Services.Factory;
using _Project.UI.ViewModels;
using _Project.Interactables;
using _Project.Services.ItemPickup;
using Reflex.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Infrastructure
{
    internal class LevelSceneInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddTransient(typeof(GameStateViewModel));
            containerBuilder.AddTransient(typeof(PlayerInventoryViewModel));
            containerBuilder.AddTransient(typeof(TooltipViewModel));
            containerBuilder.AddScoped(typeof(PlayerInventory), typeof(IPlayerInventory));
            containerBuilder.AddScoped(typeof(ItemPickup), typeof(IItemPickup));
            containerBuilder.OnContainerBuilt += ContainerBuilt;
        }

        private void ContainerBuilt(Container container)
        {
            var gameFactory = container.Resolve<IGameFactory>();
            gameFactory.CreatePlayerUI(container.Resolve<GameStateViewModel>());
            container.Resolve<IItemPickup>();
        }
    }
}
