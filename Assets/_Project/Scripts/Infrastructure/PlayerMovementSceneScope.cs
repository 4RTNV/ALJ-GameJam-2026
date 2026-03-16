using Reflex.Core;
using UnityEngine;

namespace _Project.Infrastructure
{
    public class PlayerMovementSceneScope : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddScoped(typeof(PlayerInventory), typeof(IPlayerInventory));
        }
    }
}