using _Project.Services.ItemPickup;
using Reflex.Core;
using UnityEngine;

namespace _Project.Infrastructure
{
    public class PlayerMovementSceneScope : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddScoped(typeof(PlayerInventory), typeof(IPlayerInventory));
            containerBuilder.AddScoped(typeof(ItemPickup), typeof(IItemPickup));
            containerBuilder.OnContainerBuilt += PlayerMovementContainerBuilt;
        }

        private void PlayerMovementContainerBuilt(Container container)
        {
            container.Resolve<IItemPickup>();
        }
    }
}